using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using MTREG.ihsp.bll;
using MTREG.netpay;
using MTREG.medinsur.gzsyb.bll;
using MTREG.medinsur.gzsnh.bll;

namespace Bend.Util {

    public class HttpProcessor {
        public TcpClient socket;        
        public HttpServer srv;

        private Stream inputStream;
        public Stream outputStream;

        public String http_method;
        public String http_url;
        public String http_protocol_versionstring;
        public Hashtable httpHeaders = new Hashtable();

        SortedList sortList = new SortedList();
        private string response_data="";

        public string Response_data
        {
            get { return response_data; }
            set { response_data = value; }
        }

        private static int MAX_POST_SIZE = 10 * 1024 * 1024; // 10MB

        public HttpProcessor(TcpClient s, HttpServer srv) {
            this.socket = s;
            this.srv = srv;                   
        }
        

        private string streamReadLine(Stream inputStream) {
            int next_char;
            string data = "";
            while (true) {
                next_char = inputStream.ReadByte();
                if (next_char == '\n') { break; }
                if (next_char == '\r') { continue; }
                if (next_char == -1) { Thread.Sleep(1); continue; };
                data += Convert.ToChar(next_char);
            }            
            return data;
        }
        public void process() {                        
            // we can't use a StreamReader for input, because it buffers up extra data on us inside it's
            // "processed" view of the world, and we want the data raw after the headers
            inputStream = new BufferedStream(socket.GetStream());

            // we probably shouldn't be using a streamwriter for all output from handlers either
            outputStream =new BufferedStream(socket.GetStream());
            try {
                parseRequest();
                readHeaders();
                if (http_method.Equals("GET")) {
                    handleGETRequest();
                } else if (http_method.Equals("POST")) {
                    handlePOSTRequest();
                }
            } catch (Exception e) {
                Console.WriteLine("Exception: " + e.ToString());
                writeFailure();
            }
            try
            {
                outputStream.Flush();

            }
            catch (Exception ex)
            { 
                
            }
            // bs.Flush(); // flush any remaining output
            inputStream = null; outputStream = null; // bs = null;            
            socket.Close();             
        }

        public void parseRequest() {
            String request = streamReadLine(inputStream);
            string[] tokens = request.Split(' ');
            if (tokens.Length != 3) {
                throw new Exception("invalid http request line");
            }
            http_method = tokens[0].ToUpper();
            http_url = tokens[1];
            http_protocol_versionstring = tokens[2];

            Console.WriteLine("starting: " + request);
        }

        public void readHeaders() {
            Console.WriteLine("readHeaders()");
            String line;
            while ((line = streamReadLine(inputStream)) != null) {
                if (line.Equals("")) {
                    Console.WriteLine("got headers");
                    return;
                }
                
                int separator = line.IndexOf(':');
                if (separator == -1) {
                    throw new Exception("invalid http header line: " + line);
                }
                String name = line.Substring(0, separator);
                int pos = separator + 1;
                while ((pos < line.Length) && (line[pos] == ' ')) {
                    pos++; // strip any spaces
                }
                    
                string value = line.Substring(pos, line.Length - pos);
                Console.WriteLine("header: {0}:{1}",name,value);
                httpHeaders[name] = value;
            }
        }

        public void handleGETRequest() {
            srv.handleGETRequest(this);
        }

        private const int BUF_SIZE = 4096;
        public void handlePOSTRequest() {
            // this post data processing just reads everything into a memory stream.
            // this is fine for smallish things, but for large stuff we should really
            // hand an input stream to the request processor. However, the input stream 
            // we hand him needs to let him see the "end of the stream" at this content 
            // length, because otherwise he won't know when he's seen it all! 

            Console.WriteLine("get post data start");
            int content_len = 0;
            MemoryStream ms = new MemoryStream();
            if (this.httpHeaders.ContainsKey("Content-Length")) {
                 content_len = Convert.ToInt32(this.httpHeaders["Content-Length"]);
                 if (content_len > MAX_POST_SIZE) {
                     throw new Exception(
                         String.Format("POST Content-Length({0}) too big for this simple server",
                           content_len));
                 }
                 byte[] buf = new byte[BUF_SIZE];              
                 int to_read = content_len;
                 while (to_read > 0) {  
                     Console.WriteLine("starting Read, to_read={0}",to_read);

                     int numread = this.inputStream.Read(buf, 0, Math.Min(BUF_SIZE, to_read));
                     Console.WriteLine("read finished, numread={0}", numread);
                     if (numread == 0) {
                         if (to_read == 0) {
                             break;
                         } else {
                             throw new Exception("client disconnected during post");
                         }
                     }
                     to_read -= numread;
                     ms.Write(buf, 0, numread);
                 }
                 ms.Seek(0, SeekOrigin.Begin);
            }
            Console.WriteLine("get post data end");
            srv.handlePOSTRequest(this, new StreamReader(ms));

        }
        public void WriteData()
        {
            Write(this.response_data);
          
        }
        public void Write(string text)
        {

            byte[] bytes = Encoding.UTF8.GetBytes(text);
            outputStream.Write(bytes, 0, bytes.Length);
        }
        public  void WriteLine( string text)
        {
            text += "\r\n";
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            outputStream.Write(bytes, 0, bytes.Length);
        }
        public void writeSuccess() {

            byte[] bytes = Encoding.UTF8.GetBytes(this.Response_data);
            Write( "HTTP/1.0 200 OK\r\n");
            Write( "Content-Type: text/html\r\n");
            Write( "Connection: close\r\n");
            if (bytes.Length!=0)
                Write( "Content-Length:" + bytes.Length+"\r\n");
            Write( "\r\n");

            
        }

        public void writeFailure() {
            Write( "HTTP/1.0 404 File not found\r\n");
            Write( "Connection: close\r\n");
            Write( "\r\n");
        }
        //读取参数到缓存中
        public SortedList readParam(string data)
        {
            string POSTStr = data;
            sortList.Clear();
            int index = POSTStr.IndexOf("&");
            string[] Arr = { };
            if (index != -1) //参数传递不只一项
            {
                Arr = POSTStr.Split('&');
                for (int i = 0; i < Arr.Length; i++)
                {
                    int equalindex = Arr[i].IndexOf('=');
                    string paramN = Arr[i].Substring(0, equalindex);
                    string paramV = Arr[i].Substring(equalindex + 1);
                    if (!sortList.ContainsKey(paramN))
                    //避免用户传递相同参数
                    { sortList.Add(paramN, paramV); }
                    else //如果有相同的，一直删除取最后一个值为准
                    {
                        sortList.Remove(paramN); sortList.Add(paramN, paramV);
                    }
                }
            }
            else //参数少于或等于1项
            {
                int equalindex = POSTStr.IndexOf('=');
                if (equalindex != -1)
                { //参数是1项
                    string paramN = POSTStr.Substring(0, equalindex);
                    string paramV = POSTStr.Substring(equalindex + 1);
                    sortList.Add(paramN, paramV);
                }
                else //没有传递参数过来
                { sortList = null; }
            }
            return sortList;
        }
        /// <summary>
        /// 得到参数
        /// </summary>
        /// <param name="keyname"></param>
        /// <returns></returns>
        public string getParameter(string keyname)
        {
            string retvalue = "";
            if (sortList != null)
            {
                foreach (DictionaryEntry De in sortList)
                {
                    if (keyname.Equals(De.Key))
                    {
                        retvalue = De.Value.ToString();
                        break;
                    }
                }
            }
            return retvalue;

        }
    }



    public abstract class HttpServer {

        protected int port;
        TcpListener listener;
        bool is_active = true;
       
        public HttpServer(int port) {
            this.port = port;
        }

        public void listen() {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
            }
            catch (Exception ex)
            {
                
                return;
                
            }
            while (is_active)
            {
                TcpClient s = listener.AcceptTcpClient();
                HttpProcessor processor = new HttpProcessor(s, this);
                Thread thread = new Thread(new ThreadStart(processor.process));
                thread.Start();
                Thread.Sleep(1);
            }
        }

        public abstract void handleGETRequest(HttpProcessor p);
        public abstract void handlePOSTRequest(HttpProcessor p, StreamReader inputData);
    }

    public class MyHttpServer : HttpServer {
        public MyHttpServer(int port)
            : base(port) {
        }
        public override void handleGETRequest(HttpProcessor p) {
            Console.WriteLine("request: {0}", p.http_url);
            p.writeSuccess();
            p.WriteLine("<html><body><h1>test server</h1>");
            p.WriteLine("Current Time: " + DateTime.Now.ToString());
            p.WriteLine("url : "+ p.http_url);
            p.WriteLine("<form method=post action=/form>");
            p.WriteLine("<input type=text name=foo value=foovalue>");
            p.WriteLine("<input type=submit name=bar value=barvalue>");
            p.WriteLine("</form>");
        }
       


        public override void handlePOSTRequest(HttpProcessor p, StreamReader inputData) {
            Console.WriteLine("POST request: {0}", p.http_url);
            
            
            string[] sCmd = p.http_url.Split('!');
            if(sCmd.Length<2)
            {
             p.writeFailure();
                return;
            }
            //string response_str = "";
            string data = inputData.ReadToEnd();
            p.readParam(data);
            if (sCmd[1].Equals("netpayOrderStat.do"))//5.2HIS订单状态查询
            {
               string outerOrderNo =  p.getParameter("outerOrderNo");
               string nonce_str = p.getParameter("nonce_str");
               string merchantId = p.getParameter("merchantId");
               string orgCode = p.getParameter("orgCode");
               string merId = p.getParameter("merId");
             
               NetpayBll netpayBll = new NetpayBll();
             string response_str =  netpayBll.netpayOrderStat(outerOrderNo,nonce_str,merchantId,orgCode,merId);
                p.Response_data = response_str;
                Console.WriteLine("POST request CMD: netpayOrderStat.do");
            }
            else if (sCmd[1].Equals("netpayOrderList.do"))//5.1HIS对账单查询
            { 
                NetpayBll netpayBll = new NetpayBll();
                string startDate = p.getParameter("startDate");
                string endDate = p.getParameter("endDate");
                string nonce_str = p.getParameter("nonce_str");
                string merchantId = p.getParameter("merchantId");
                string orgCode = p.getParameter("orgCode");
                string merId = p.getParameter("merId");
                string response_str = netpayBll.netpayOrderList( startDate,  endDate,  nonce_str,  merchantId,  orgCode,  merId);
                p.Response_data = response_str;
                Console.WriteLine("POST request CMD: netpayOrderList.do");
            }
            else if (sCmd[1].Equals("ihpsPreAccount.do"))
            {
                string ihsp_id = p.getParameter("ihsp_id");
                BillIhspAct bllIhspAct = new BillIhspAct();
                string response_str = "<response>"
                 + "<resultCode>0</resultCode>"
                 + "<resultMessage>成功</resultMessage>";
                if(!bllIhspAct.NursYjs(ihsp_id))
                {
                    response_str = "<response>"
                 + "<resultCode>-1</resultCode>"
                 + "<resultMessage>失败</resultMessage>";
                }
                p.Response_data = response_str;
                Console.WriteLine("POST request CMD: ihpsPreAccount.do");
            }
            else if (sCmd[1].Equals("nursPayinadvNetPay.do"))
            { 
                string ihsp_id = p.getParameter("ihsp_id");
                string chk_authCode = p.getParameter("chk_authCode");
                string bas_paytype_id = p.getParameter("bas_paytype_id");
                string payfee = p.getParameter("payfee");
                string operid = p.getParameter("operid");
                string merId = p.getParameter("merId");
                string mesg="";
                BillIhspMan billIhspMan = new BillIhspMan();
                string response_str = "";
                if (!billIhspMan.doNursPayinadvNetPay(ihsp_id, chk_authCode, bas_paytype_id, payfee, operid, ref mesg))
                {

                    response_str = "<response>"
                     + "<resultCode>-1</resultCode>"
                     + "<resultMessage>" + mesg + "</resultMessage>";

                }
                else
                {
                 response_str ="<response>"
                + "<resultCode>0</resultCode>"
                + "<resultMessage>" + mesg + "</resultMessage>";
                }
                p.Response_data = response_str;
            }
            else if (sCmd[1].Equals("insurItemGZSYB.do"))
            {
                string mesg = "下载目录成功";
                string response_str = "";
                Gzsybservice Swybservice = new Gzsybservice();
                string lasttime = p.getParameter("lasttime");
                if (!Swybservice.xzfwxmml(lasttime))
                {
                    mesg = "下载目录失败";
                    response_str = "<response>"
                     + "<resultCode>-1</resultCode>"
                     + "<resultMessage>" + mesg + "</resultMessage>";
                }
                else
                {
                    response_str = "<response>"
                   + "<resultCode>0</resultCode>"
                   + "<resultMessage>" + mesg + "</resultMessage>";
                }
                p.Response_data = response_str;


            }
            else if (sCmd[1].Equals("insurItemGZSNH.do"))
            {
                string mesg = "下载目录成功";
                string response_str = "";
                string lasttime = p.getParameter("lasttime");
                BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
                if (!bllGzsnhMethod.insurItemGZSNH(lasttime, ref mesg))
                {
                    mesg = "下载目录失败";
                    response_str = "<response>"
                     + "<resultCode>-1</resultCode>"
                     + "<resultMessage>" + mesg + "</resultMessage>";
                }
                else
                {
                    response_str = "<response>"
                   + "<resultCode>0</resultCode>"
                   + "<resultMessage>" + mesg + "</resultMessage>";
                }
                p.Response_data = response_str;
            
            }
            else if (sCmd[1].Equals("insurItemGYSNH.do"))
            {
                string mesg = "下载目录成功";
                string response_str = "";
                string lasttime = p.getParameter("lasttime");
                BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
                if (!bllGzsnhMethod.insurItemGYSNH(lasttime, ref mesg))
                {
                    mesg = "下载目录失败";
                    response_str = "<response>"
                     + "<resultCode>-1</resultCode>"
                     + "<resultMessage>" + mesg + "</resultMessage>";
                }
                else
                {
                    response_str = "<response>"
                   + "<resultCode>0</resultCode>"
                   + "<resultMessage>" + mesg + "</resultMessage>";
                }
                p.Response_data = response_str;
            
            }
            else
            {
                string mesg = "调用协议错误";
               string response_str = "<response>"
                      + "<resultCode>-1</resultCode>"
                      + "<resultMessage>" + mesg + "</resultMessage>";
               p.Response_data = response_str;
            }
            p.writeSuccess();
            p.WriteData();
            
        }
    }
    
    //public class TestMain {
    //    public static int Main(String[] args) {
    //        HttpServer httpServer;
    //        if (args.GetLength(0) > 0) {
    //            httpServer = new MyHttpServer(Convert.ToInt16(args[0]));
    //        } else {
    //            httpServer = new MyHttpServer(8080);
    //        }
    //        Thread thread = new Thread(new ThreadStart(httpServer.listen));
    //        thread.Start();
    //        return 0;
    //    }

    //}

}




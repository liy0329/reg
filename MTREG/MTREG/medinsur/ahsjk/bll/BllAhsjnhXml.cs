using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Services.Description;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Xml;
using System.Reflection;

namespace MTREG.medinsur.ahsjk.bll
{
    class BllAhsjnhXml
    {
        /// <summary>
        /// 动态调用WebService
        /// </summary>
        /// <param name="url">WebService地址</param>
        /// <param name="classname">类名</param>
        /// <param name="methodname">方法名(模块名)</param>
        /// <param name="args">参数列表</param>
        /// <returns>object</returns>
        public object InvokeWebService(string url,string methodname, string[] args)
        {
            string classname = "IJQCenterWebService";
            //1. 使用 WebClient 下载 WSDL 信息。
            WebClient wc = new WebClient();

            //string cc = url+"?WSDL";
            Stream stream = wc.OpenRead(url + "?WSDL");
            //2. 创建和格式化 WSDL 文档。
            ServiceDescription sd = ServiceDescription.Read(stream);

            // 3. 创建客户端代理代理类。
            ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
            sdi.AddServiceDescription(sd, "", "");// 添加 WSDL 文档。

            // 4. 使用 CodeDom 编译客户端代理类。
            CodeNamespace cn = new CodeNamespace();

            CodeCompileUnit ccu = new CodeCompileUnit();//为代理类添加命名空间，缺省为全局空间。
            ccu.Namespaces.Add(cn);
            sdi.Import(cn, ccu);
            CSharpCodeProvider csc = new CSharpCodeProvider();
            ICodeCompiler icc = csc.CreateCompiler();
            //5.设定编译器的参数
            CompilerParameters cplist = new CompilerParameters();
            cplist.GenerateExecutable = false;
            cplist.GenerateInMemory = true;
            cplist.ReferencedAssemblies.Add("System.dll");
            cplist.ReferencedAssemblies.Add("System.XML.dll");
            cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
            cplist.ReferencedAssemblies.Add("System.Data.dll");
            //6.获取编译代理类
            CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);


            if (true == cr.Errors.HasErrors)
            {
                System.Text.StringBuilder sb = new StringBuilder();
                foreach (CompilerError ce in cr.Errors)
                {
                    sb.Append(ce.ToString());
                    sb.Append(System.Environment.NewLine);
                }
                throw new Exception(sb.ToString());
            }

            //7. 使用 Reflection 调用 WebService。
            System.Reflection.Assembly assembly = cr.CompiledAssembly;
            Type t = assembly.GetType(classname, true, true);
            object obj = Activator.CreateInstance(t);//【10】
            System.Reflection.MethodInfo mi = t.GetMethod(methodname);//【11】
            return mi.Invoke(obj, args);
        }

        /// <summary>
        /// 解析Xml
        /// </summary>
        /// <param name="sResult"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public  List<object> parseResult(string sResult, Type type)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(sResult);
            XmlNode rootNode = xmlDoc.SelectSingleNode("JQWebService");
            XmlNode countNode = rootNode.FirstChild;
            int rowCount = int.Parse(countNode.InnerText);
            rootNode.RemoveChild(countNode);
            List<object> list = new List<object>(rowCount);
            XmlNodeList rowNodes = rootNode.ChildNodes;
            foreach (XmlNode rowNode in rowNodes)
            {
                object inst = Activator.CreateInstance(type);
                XmlNodeList attrNodes = rowNode.ChildNodes;
                foreach (XmlNode attrNode in attrNodes)
                {
                    PropertyInfo prop = type.GetProperty(attrNode.Name);
                    prop.SetValue(inst, attrNode.InnerText, null);
                }
                list.Add(inst);
            }
            return list;
        } 
    }
}

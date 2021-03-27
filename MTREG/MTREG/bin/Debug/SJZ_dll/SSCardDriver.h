#include "resource.h"



	 long __stdcall iCommReadCardBas(char* wsdlAddress,char* userId,char* password,char* authKey,int iType,char *pOutInfo);	
	 long __stdcall iCommReadCard(char* wsdlAddress,char* userId,char* password,char* authKey,int iType,int iAuthType,char* pCardInfo,char* pFileAddr,char *pOutInfo); 
	 long __stdcall iCommWriteCard(char* wsdlAddress,char* userId,char* password,char* authKey,int iType,char* pCardInfo,char* pFileAddr,char* pWriteData,char *pOutInfo);	
	 long __stdcall iCommReloadPIN(char* wsdlAddress,char* userId,char* password,char* authKey,int iType,char *pCardInfo,char* pOutInfo);
	 long __stdcall iCommUnblockPIN(char* wsdlAddress,char* userId,char* password,char* authKey,int iType,char*pCardInfo,char* pOutInfo);
	 long __stdcall iCommDoDebit (char* wsdlAddress,char* userId,char* password,char* authKey,int iType,char*pCardInfo,char* pPayInfo,char* pOutInfo);

	 long __stdcall iReadCardBas(int iType,char *pOutInfo);
	 long __stdcall iGetReaderInfo(char* pReaderSN, char* pPsamTermNo);	
	 long __stdcall iReadCard(int iType,int iAuthType,char* pCardInfo,char* pFileAddr,char *pOutInfo); 
	 long __stdcall iWriteCard(int iType,char* pCardInfo,char* pFileAddr,char* pWriteData,char *pOutInfo);	
	 long __stdcall iVerifyPIN(int iType,char* pOutInfo);	
	 long __stdcall iChangePIN(int iType,char* pOutInfo);
	 long __stdcall iReloadPIN(int iType,char *pCardInfo,char* pOutInfo);
	 long __stdcall iUnblockPIN(int iType,char*pCardInfo,char* pOutInfo);
	 long __stdcall iDoDebit(int iType,char*pCardInfo,char* pPayInfo,char* pOutInfo);
	 long __stdcall iReadDebitRecord(int iType,char* pOutInfo);
	 long __stdcall iGetCardType(unsigned char* pCardType, char* pOutInfo);
	 long __stdcall iGetReaderInfo(char* pReaderSN, char* pPsamTermNo);

	 long __stdcall iReadCardBas_HSM_Step1(int iType,char *pOutInfo);
	 long __stdcall iReadCardBas_HSM_Step2(char *pKey,char* pOutInfo);

	 long __stdcall iReadCard_HSM_Step1(int iType,char* pCardInfo,char *pFileAddr,char *pOutInfo);
	 long __stdcall iReadCard_HSM_Step2(char* pKey,char *pOutInfo);

	 long __stdcall iWriteCard_HSM_Step1(int iType,char* pCardInfo,char *pFileAddr,char *pOutInfo);
	 long __stdcall iWriteCard_HSM_Step2(char* pKey,char *pWriteData,char *pOutInfo);

	 long __stdcall iReloadPIN_HSM_Step1(int iType,char*pCardInfo,char *pOutInfo);
 	 long __stdcall iReloadPIN_HSM_Step2(char* pKey,char *pOutInfo);
	 long __stdcall iReloadPIN_HSM_Step3(char* pKey,  char*pOutInfo);

	 long __stdcall iUnblockPIN_HSM_Step1(int iType,char*pCardInfo,char *pOutInfo);
	 long __stdcall iUnblockPIN_HSM_Step2(char* pKey,char *pOutInfo);
	 long __stdcall iUnblockPIN_HSM_Step3(char* pKeyData,char *pOutInfo);

	 long __stdcall iDoDebit_HSM_Step1(int iType,char *pCardInfo,char *pPayInfo,char *pOutInfo);
	 long __stdcall iDoDebit_HSM_Step2(char *pKey,char *pOutInfo);

	 typedef long __stdcall IREADCARDBAS(int iType,char *pOutInfo);
	 typedef long __stdcall IREADCARD(int iType,int iAuthType,char* pCardInfo,char* pFileAddr,char *pOutInfo);
	 typedef long __stdcall IWRITECARD(int iType,char* pCardInfo,char* pFileAddr,char* pWriteData,char *pOutInfo);
	 typedef long __stdcall IVERIFYPIN(int iType,char* pOutInfo);	
	 typedef long __stdcall ICHANGEPIN(int iType,char* pOutInfo);
	 typedef long __stdcall IRELOADPIN(int iType,char *pCardInfo,char* pOutInfo);
	 typedef long __stdcall IUNBLOCKPIN(int iType,char*pCardInfo,char* pOutInfo);
	 typedef long __stdcall IDODEBIT(int iType,char*pCardInfo,char* pPayInfo,char* pOutInfo);
	 typedef long __stdcall IREADDEBITRECORD(int iType,char* pOutInfo);
	 typedef long __stdcall IGETCARDTYPE(unsigned char* pCardType, char* pOutInfo);
	 typedef long __stdcall IGETREADERINFO(char* pReaderSN, char* pPsamTermNo);

	 typedef long __stdcall IREADCARDBAS_HSM_STEP1(int iType,char *pOutInfo);
	 typedef long __stdcall IREADCARDBAS_HSM_STEP2(char *pKey,char* pOutInfo);

	 typedef long __stdcall IREADCARD_HSM_STEP1(int iType,char* pCardInfo,char *pFileAddr,char *pOutInfo);
	 typedef long __stdcall IREADCARD_HSM_STEP2(char* pKey,char *pOutInfo);

	 typedef long __stdcall IWRITECARD_HSM_STEP1(int iType,char* pCardInfo,char *pFileAddr,char *pOutInfo);
	 typedef long __stdcall IWRITECARD_HSM_STEP2(char* pKey,char *pWriteData,char *pOutInfo);

	 typedef long __stdcall IRELOADPIN_HSM_STEP1(int iType,char*pCardInfo,char *pOutInfo);
	 typedef long __stdcall IRELOADPIN_HSM_STEP2(char* pKey,char *pOutInfo);
	 typedef long __stdcall IRELOADPIN_HSM_STEP3(char* pKey,  char*pOutInfo);

	 typedef long __stdcall IUNBLOCKPIN_HSM_STEP1(int iType,char*pCardInfo,char *pOutInfo);
	 typedef long __stdcall IUNBLOCKPIN_HSM_STEP2(char* pKey,char *pOutInfo);
	 typedef long __stdcall IUNBLOCKPIN_HSM_STEP3(char* pKeyData,char *pOutInfo);

	 typedef long __stdcall IDODEBIT_HSM_STEP1(int iType,char *pCardInfo,char *pPayInfo,char *pOutInfo);
	 typedef long __stdcall IDODEBIT_HSM_STEP2(char *pKey,char *pOutInfo);
	 typedef long __stdcall IREADCARD(int iType,int iAuthType,char* pCardInfo,char* pFileAddr,char *pOutInfo);
	 typedef long __stdcall IWRITECARD(int iType,char* pCardInfo,char* pFileAddr,char* pWriteData,char *pOutInfo);
	 typedef long __stdcall IVERIFYPIN(int iType,char* pOutInfo);	
	 typedef long __stdcall ICHANGEPIN(int iType,char* pOutInfo);
	 typedef long __stdcall IRELOADPIN(int iType,char *pCardInfo,char* pOutInfo);
	 typedef long __stdcall IUNBLOCKPIN(int iType,char*pCardInfo,char* pOutInfo);
	 typedef long __stdcall IDODEBIT(int iType,char*pCardInfo,char* pPayInfo,char* pOutInfo);
	 typedef long __stdcall IREADDEBITRECORD(int iType,char* pOutInfo);
	 typedef long __stdcall IGETCARDTYPE(unsigned char* pCardType, char* pOutInfo);
 //ÀÏ¶¯Ì¬¿â
int __stdcall iDOpenPort(int iReaderPort, int *iReaderHandle, char *iERRInfo);
int __stdcall iDCloseReader(int iReaderHandle, char *iERRInfo);
int __stdcall iPChangePIN(int iReaderHandle, const char *szOldPasswd, const char *szNewPasswd, char *iERRInfo);
int __stdcall iPReloadPIN(int iReaderHandle, const char *szCardPasswd, char *iERRInfo);
int __stdcall iPInputPIN(int iReaderHandle, const char *szPasswd, char *iERRInfo);
int __stdcall iPOutputPIN(int iReaderHandle, char *szPasswd, char *iERRInfo);
int __stdcall iBAppBlock(int iReaderHandle, const char *szAppType, char *iERRInfo);
int __stdcall iRCardInfo(int iReaderHandle, const char *iVerInfo, const char *iPassword,
						 const char *iFileAddr, char *iFileData, char *iERRInfo);
int __stdcall iWCardInfo(int iReaderHandle, const char *iVerInfo, const char *iPassword,
						 const char *iFileAddr, const char *iFileData, char *iERRInfo);
int __stdcall iRMFFingerPrintInfo(int iReaderHandle, char *bFingerPrint, char *iERRInfo);
int __stdcall iWMFFingerPrintInfo(int iReaderHandle, const char *bFingerPrint, char *iERRInfo);
int __stdcall iGetPSAMcode(int iReaderHandle, char *ipsamcode, char *idevicecode, char *iERRInfo);
int __stdcall getCardATR(int iReaderHandle, char *ATR, char *iERRInfo);
int __stdcall iRPSAMCardInfo(int iReaderHandle, char *psamid, char *iERRInfo);
int __stdcall iRCardType(int iReaderHandle, char *cardtype, char *iERRInfo);
int __stdcall ICC_verify(int iReaderHandle, char pin_len, char *pin);
int __stdcall ICC_change_pin(int iReaderHandle, char pin_len, char *oldpin, char *newpin);
int __stdcall ICC_read_bin(int iReaderHandle, int offset, int len, char *data);
int __stdcall ICC_write_bin(int iReaderHandle, int offset, int len, char *data);
int __stdcall getCardNO(int iReaderHandle, char *iCardNo, char *iERRInfo);


typedef int WINAPI IRCARDINFO(int iReaderHandle, const char *iVerInfo, const char *iPassword, 
							  const char *iFileAddr ,char *iFileData, char *iERRInfo);
typedef int WINAPI IWCARDINFO(int iReaderHandle, const char *iVerInfo, const char *iPassword, 
							  const char *iFileAddr ,const char *iFileData, char *iERRInfo);
typedef int WINAPI IDOPENPORT(int iReaderPort,int *iReaderHandle,char *iERRInfo);
typedef int WINAPI IDCLOSEREADER(int iReaderHandle,char *iERRInfo);
typedef int WINAPI IPCHANGEPIN(int iReaderHandle, const char *szOldPasswd, const char *szNewPasswd, char *iERRInfo);
typedef int WINAPI IPRELOADPIN(int iReaderHandle,const char *szCardPasswd,char *iERRInfo);
typedef int WINAPI IPINPUTPIN(int iReaderHandle, const char *szPasswd,char *iERRInfo);
typedef int WINAPI IRMFFINGERPRINTINFO(int iReaderHandle, char *bFingerPrint,char *iERRInfo);
typedef int WINAPI IWMFFINGERPRINTINFO(int iReaderHandle, const char *bFingerPrint, char *iERRInfo);
typedef int WINAPI IGETPSAMCODE(int iReaderHandle,char *ipsamcode,char *idevicecode, char *iERRInfo);
typedef int WINAPI IGETCARDATR(int iReaderHandle, char *ATR, char *iERRInfo);
typedef int WINAPI IBAPPBLOCK(int iReaderHandle, const char *szAppType, char *iERRInfo);

typedef int WINAPI IRCARDTYPE(int iReaderHandle, char *cardtype, char *iERRInfo);
typedef int WINAPI ICC_VERIFY(int iReaderHandle, char pin_len, char *pin);
typedef int WINAPI ICC_CHANGE_PIN(int iReaderHandle, char pin_len, char *oldpin, char *newpin);
typedef int WINAPI ICC_READ_BIN(int iReaderHandle, int offset, int len, char *data);
typedef int WINAPI ICC_WRITE_BIN(int iReaderHandle, int offset, int len, char *data);

typedef int WINAPI GETCARDNO(int iReaderHandle, char *icardno, char *iERRInfo);
typedef int WINAPI IRPSAMCARDINFO(int iReaderHandle, char *icardno, char *iERRInfo);
typedef int WINAPI IPOUTPUTPIN(int iReaderHandle, const char *szPasswd,char *iERRInfo);

#ifndef SSCARDDRIVER_H_
#define SSCARDDRIVER_H_ 


#ifdef __cplusplus
extern "C" {
#endif

	long __stdcall iReadCard(int iType,int iAuthType,char* pCardInfo,char* pFileAddr,char *pOutInfo); 
	long __stdcall iWriteCard(int iType,char* pCardInfo,char* pFileAddr,char* pWriteData,char *pOutInfo);
	long __stdcall iReadCardBas(int iType,char *pOutInfo);	
	long __stdcall iVerifyPIN(int iType,char* pOutInfo);	
	long __stdcall iChangePIN(int iType,char* pOutInfo);
	long __stdcall iReloadPIN(int iType,char *pCardInfo,char* pOutInfo);
	long __stdcall iUnblockPIN(int iType,char*pCardInfo,char* pOutInfo);
	long __stdcall iDoDebit(int iType,char*pCardInfo,char* pPayInfo,char* pOutInfo);
	long __stdcall iReadDebitRecord(int iType,char* pOutInfo);

	long __stdcall iReadCardBas_HSM_Step1(int iType,char *pOutInfo);
	long __stdcall iReadCardBas_HSM_Step1To2(int iType,char*pAuthSourceInfo,char *pAuthInfo);
	long __stdcall iReadCardBas_HSM_Step2(char *pKey,char* pOutInfo);

	long __stdcall iReadCard_HSM_Step1(int iType,char* pCardInfo,char *pFileAddr,char *pOutInfo);
	long __stdcall iReadCard_HSM_Step1To2(int iType,char*pAuthSourceInfo,char *pAuthInfo);
	long __stdcall iReadCard_HSM_Step2(char* pKey,char *pOutInfo);

	long __stdcall iWriteCard_HSM_Step1(int iType,char* pCardInfo,char *pFileAddr,char *pOutInfo);
	long __stdcall iWriteCard_HSM_Step1To2(int iType,char*pAuthSourceInfo,char *pAuthInfo);
	long __stdcall iWriteCard_HSM_Step2(char* pKey,char *pWriteData,char *pOutInfo);

	long __stdcall iReloadPIN_HSM_Step1(int iType,char*pCardInfo,char *pOutInfo);
	long __stdcall iReloadPIN_HSM_Step1To2(int iType,char*pAuthSourceInfo,char *pAuthInfo);
	long __stdcall iReloadPIN_HSM_Step2(char* pKey,char *pOutInfo);
	long __stdcall iReloadPIN_HSM_Step2To3(char* pKeyData,char *pOutInfo);
	long __stdcall iReloadPIN_HSM_Step3(char* pKey,  char*pOutInfo);

	long __stdcall iUnblockPIN_HSM_Step1(int iType,char*pCardInfo,char *pOutInfo);
	long __stdcall iUnblockPIN_HSM_Step1To2(int iType,char*pAuthSourceInfo,char *pAuthInfo) ;
	long __stdcall iUnblockPIN_HSM_Step2(char* pKey,char *pOutInfo);
	long __stdcall iUnblockPIN_HSM_Step2To3(char* pKeyData,char *pOutInfo);
	long __stdcall iUnblockPIN_HSM_Step3(char* pKeyData,char *pOutInfo);

	long __stdcall iDoDebit_HSM_Step1(int iType,char *pCardInfo,char *pPayInfo,char *pOutInfo);
	long __stdcall iDoDebit_HSM_Step1To2(char *pMAC1Sourceinfo,char *pMAC1);
	long __stdcall iDoDebit_HSM_Step2(char *pKey,char *pOutInfo);

	long __stdcall iGetCardType(unsigned char* pCardType, char* pOutInfo);
	long __stdcall iGetReaderInfo(char* pReaderSN, char* pPsamTermNo);

	long __stdcall iEnterCard(char *pErrMsg);
	long __stdcall iExitCard(char *pErrMsg);

	long __stdcall iReadIdentityCard(char *pOutInfo, char *pErrMsg);

	long __stdcall iGetTwoBarCodes(int iTimeOut, char *pOutInfo);
	long __stdcall iReadCertificate(int *piFingerLen, unsigned char *pucFinger, char* pOutInfo);

#ifdef __cplusplus
}
#endif
#endif
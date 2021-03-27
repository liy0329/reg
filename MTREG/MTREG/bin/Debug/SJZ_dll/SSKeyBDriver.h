#ifndef SSKEYBDRIVER_H_
#define SSKEYBDRIVER_H_

#ifdef __cplusplus
extern "C" {
#endif

	long __stdcall iReaderGetPass(unsigned char ctimeout,char *cdsp,unsigned char audiocmd,unsigned char *cpasslen,char * cpass);
typedef long __stdcall IREADERGETPASS(unsigned char ctimeout, char *cdsp, unsigned char audiocmd, unsigned char *cpasslen,  char * cpass);

#ifdef __cplusplus
}
#endif

#endif

	
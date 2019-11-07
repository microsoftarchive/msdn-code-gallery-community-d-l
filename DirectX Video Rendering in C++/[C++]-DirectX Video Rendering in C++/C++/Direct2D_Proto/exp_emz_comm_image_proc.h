/*
*******************************************************************************
                       Copyright Aricent Inc., 2005-2008.
*  All rights Reserved, Licensed Software Confidential and Proprietary Information of
*  Aricent Inc. made available under Non-Disclosure Agreement OR License as applicable.
*
All rights Reserved, Licensed Software Confidential and Proprietary Information 
    of Aricent Incorporation Made available under Non-Disclosure Agreement OR
*  All rights Reserved, Licensed Software Confidential and Proprietary Information of
*  Aricent Inc. made available under Non-Disclosure Agreement OR License as applicable.
*
                            License as applicable.
*******************************************************************************
*/
#include "exp_emz_common.h"

#ifndef INCLUDE_EMZIPALG
#define INCLUDE_EMZIPALG

/* Common error code definitions */
#define E_EMZ_SUCCESS            0
#define E_EMZ_FAILURE           (-1)
#define E_EMZ_OUT_OF_MEMORY     (-2)
#define E_EMZ_INVALID_ARGS      (-3)
#define E_EMZ_NOT_SUPPORTED     (-4)
#define COLOR_CONV_PRECISION    14

typedef enum {

		EMZ_YUV400,
		EMZ_YUV420,
		EMZ_YUV422,
		EMZ_YUV444,
		EMZ_YUVxxx,  /* Reserved */
		EMZ_RGB888,
		EMZ_RGB565,
		EMZ_XRGB4444,
		EMZ_XRGB8888,
		EMZ_RGB555,
		EMZ_BGR565,
		EMZ_BGR888

}tEmzColForm;

typedef enum {

		EMZ_YUV422H_PLANAR,
		EMZ_YUV422V_PLANAR,
		EMZ_YUV_PLANAR,
		EMZ_Y_PLANAR,
		EMZ_INTRLV_RGB888,
		EMZ_INTRLV_RGB555,
		EMZ_RGB888_PLANAR,
		EMZ_INTRLV_VYUY422,
		EMZ_INTRLV_RGB565,
		EMZ_INTRLV_YUV444,
		EMZ_INTRLV_YUYV422,
		EMZ_INTRLV_YUV422,
		EMZ_INTRLV_YUVY422,
		EMZ_INTRLV_YVYU422,	
		EMZ_INTRLV_YYYYUV420,
		EMZ_INTRLV_UYVY422,		
		EMZ_INTRLV_XRGB4444,
		EMZ_INTRLV_XRGB8888,
		EMZ_INTRLV_BGR565,
		EMZ_INTRLV_BGR888,
		EMZ_INTRLV_Y1UY2V422,	
		EMZ_INTRLV_Y1VY2U422,	
		EMZ_INTRLV_UY1VY2422,
		EMZ_INTRLV_Y2VY1U422,
		EMZ_INTRLV_Y1UVY2422,	
		EMZ_INTRLV_VY1UY2422,	
		EMZ_INTRLV_VY2UY1422,					
		EMZ_RGB_PLANAR,			
		EMZ_RGB_INTRLV,
		EMZ_INTRLV_RESERVED1,/*Reserved*/
		EMZ_INTRLV_RESERVED2

}tEmzIntrlvFormat;


typedef struct{

	tEmzUint8* Ptr1;    //0
	tEmzUint8* Ptr2;    //4
	tEmzUint8* Ptr3;    //8

	tEmzInt32 ActWidth;   //0xc
	tEmzInt32 ActHeight;  //0x10
	
	tEmzInt32 CropWidth;  //0x14  
	tEmzInt32 CropHeight; //0x18
	tEmzInt32 Xoffset;    //0x1c
	tEmzInt32 Yoffset;    //0x20
	
	tEmzInt32 wndWidth;   //0x24
	tEmzInt32 wndHeight;  //0x28
	
	tEmzInt32 EnableCropping; //0x2c
	tEmzColForm ColFormat;
	tEmzIntrlvFormat InterleaveFormat;
			
}tFrameData;


#define SOURCE_PADDING_OFFSET 80


#ifdef __cplusplus
extern "C"
{
#endif /* __cplusplus */

tEmzInt32 MFW_Scale_RGB565_INTRLV_BICB_IPALG(tFrameData *, tFrameData *);

tEmzInt32 MFW_Scale_RGB565_INTRLV_IPALG(tFrameData *, tFrameData *);

tEmzInt32 MFW_Scale_RGB888_INTRLV_BICB_IPALG(tFrameData *, tFrameData *);

tEmzInt32 MFW_Scale_RGB888_INTRLV_IPALG(tFrameData *, tFrameData *);

tEmzInt32 MFW_Scale_BGR888_INTRLV_BICB_IPALG(tFrameData *, tFrameData *);

tEmzInt32 MFW_ColConv_RGB888I_RGB565I_IPALG(tFrameData * ,tFrameData *);

tEmzInt32 MFW_ColConv_BGR888I_RGB565I_IPALG(tFrameData * ,tFrameData *);

tEmzInt32 MFW_ColConv_RGB565I_RGB888I_IPALG(tFrameData * ,tFrameData *);

tEmzInt32 MFW_ColConv_RGB565_YUV420P_IPALG(tFrameData * ,tFrameData *);

tEmzInt32 MFW_ColConv_RGB565_YUV420P_BICB_IPALG(tFrameData * ,tFrameData *);

/* Proto type for ColorConvert with Rotate API functions */
tEmzInt32 MFW_ColConv_Rotate_RGB565I_YUV420P_IPALG(tFrameData* , tFrameData* ,tEmzInt32);
tEmzInt32 MFW_ColConv_Rotate_RGB888I_YUV420P_IPALG(tFrameData* , tFrameData* ,tEmzInt32);

/* Proto type for Rotate API functions */
tEmzInt32 MFW_Rotate_RGB565_INTRLV_2BUFF_IPALG(tFrameData*, tFrameData*,tEmzUint32);
tEmzInt32 MFW_Rotate_RGB888_INTRLV_2BUFF_IPALG(tFrameData*, tFrameData*,tEmzUint32);
tEmzInt32 MFW_Rotate_YUV420_PLANAR_CHR2_IPALG(tFrameData*, tFrameData*,tEmzUint32);

tEmzInt32 gColConv_YUYVI_BGR888I_IPALG(tFrameData*,tFrameData*);
tEmzInt32 gColConv_YUYVI_YUV420P_IPALG(tFrameData* yuyvFrame,tFrameData* yuvFrame);
tEmzInt32 gColConv_YUV420P_YUYVI_IPALG(tFrameData* yuvFrame, tFrameData* yuyvFrame);

void sDiffuse(tEmzInt32 , tEmzInt32 , tEmzInt32 , tEmzInt32 , tEmzInt32 ,
              tEmzUint8 *, tEmzInt32 , tEmzUint8 );
    
tEmzInt32 gColConv_EmzIPALG(tFrameData* ,tFrameData*);

tEmzInt32 gColConv_Rotate_EmzIPALG(tFrameData* ,tFrameData* ,tEmzInt32 );

tEmzInt32  gScale_YUV420_PLANAR_DownBY2_IPALG(tFrameData *srcImage, tFrameData *dstImage);

tEmzInt32 gColConv_YUV420P_RGBAI(tFrameData* aInputFrame, tFrameData* aOutputFrame);

tEmzInt32 gColConv_YUV420P_ARGBI(tFrameData*, tFrameData*);

#ifndef YUV420P_BGRAI_SMP
tEmzInt32 gColConv_YUV420P_BGRAI(tFrameData*, tFrameData*);
#else
tEmzInt32 gColConv_YUV420P_BGRAI_SMP(tFrameData*, tFrameData*, tEmzInt32);
#endif
tEmzInt32 gColConv_YUV420P_RGB565I_IPALG(tFrameData* , tFrameData*);
#ifdef __cplusplus
}
#endif /* __cplusplus */

#endif


/*
*******************************************************************************
                       Copyright (C) 2010 Aricent Inc . 
All rights Reserved, Licensed Software Confidential and Proprietary Information
    of Aricent Incorporation Made available under Non-Disclosure Agreement OR
                            License as applicable.
*******************************************************************************
*/

/*
*******************************************************************************
Product     : Common Resource
File        : exp_emz_common.h
Description : This is the commom header to be used by all components and modules.

Revision Record:
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Date                Id          Author				Comment
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Dec 3, 2012                Anusha K,Satish Hiremath           Initial Code
*******************************************************************************
*/

#ifndef INCLUDE_EXP_EMZ_COMMON
#define INCLUDE_EXP_EMZ_COMMON

#ifdef __cplusplus
extern "C"
{
#endif /* __cplusplus */

/* Data type definitions */
typedef signed char          tEmzInt8;
typedef unsigned char        tEmzUint8;
typedef short int            tEmzInt16;
typedef unsigned short int   tEmzUint16;
typedef int                  tEmzInt32;
typedef unsigned int         tEmzUint32;

typedef float                tEmzFlt32;
typedef double               tEmzFlt64;

typedef unsigned char        tEmzBool;
typedef signed int           tEmzError;

#ifdef EMZ_64BIT_MACHINE
    typedef unsigned long long int tEmzUint64;
#endif

#define E_EMZ_TRUE               1
#define E_EMZ_FALSE              0

#define E_EMZ_ON                 1
#define E_EMZ_OFF                0

/* Common error code definitions */
#define E_EMZ_SUCCESS            0
#define E_EMZ_FAILURE           (-1)
#define E_EMZ_OUT_OF_MEMORY     (-2)
#define E_EMZ_INVALID_ARGS      (-3)
#define E_EMZ_NOT_SUPPORTED     (-4)

/* Individual component error code base definitions */
#define E_EMZ_AUDIO_DECODER_ERROR_BASE   ((tEmzInt32) -1000)

#define E_EMZ_AUDIO_ENCODER_ERROR_BASE   ((tEmzInt32) -2000)

#define E_EMZ_VIDEO_DECODER_ERROR_BASE   ((tEmzInt32) -3000)

#define E_EMZ_VIDEO_ENCODER_ERROR_BASE   ((tEmzInt32) -4000)

#define E_EMZ_IMAGE_DECODER_ERROR_BASE   ((tEmzInt32) -5000)

#define E_EMZ_IMAGE_ENCODER_ERROR_BASE   ((tEmzInt32) -6000)

#define E_EMZ_SYSTEM_ERROR_BASE          ((tEmzInt32)-10000)

#ifdef __cplusplus
}
#endif  /*__cplusplus */

#endif  /* INCLUDE_EXP_EMZ_COMMON */


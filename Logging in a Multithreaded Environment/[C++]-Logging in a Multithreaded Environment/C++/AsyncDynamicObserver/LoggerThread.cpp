/**********************************************************************
*
* LoggerThread.h: Definition of LoggerThread
*
* Thread to generate log messages
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#include "stdafx.h"
#include "LoggerThread.h"
#include "LogMessage.h"
#include "LogDistributor.h"

#include <sstream>

short LoggerThread::m_ssTimeMultiplcator = 0;

/**********************************************************************
*
* LoggerThread::Operation
*
* Description: Do the thead's job here. To stop it, call End(false);
*
**********************************************************************/
void LoggerThread::Operation()
{
  std::ostringstream message;

  message << ++m_lMessageNo << " sent by Thread ID " << m_dwThreadId;

  LogDistributor::Instance().Log(LogMessage(LogMessage::evGUI, 
    LogMessage::evTrace, message.str()));

  ::Sleep(75 * m_sTimeMultiplcator);
}
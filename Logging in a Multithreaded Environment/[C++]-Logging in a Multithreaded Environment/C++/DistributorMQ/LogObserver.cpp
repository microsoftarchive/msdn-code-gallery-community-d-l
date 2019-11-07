/**********************************************************************
*
* LogObserver.h: Definition of LogObserver
*
* The LogObserver base class
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#include "stdafx.h"
#include "LogObserver.h"
#include "LogDistributor.h"

/**********************************************************************
*
* LogObserver::LogObserver
*
* Description: Constructor
*
* Exceptions: INVALID_HANDLE_VALUE if the log semaphore could not be created
*
**********************************************************************/
LogObserver::LogObserver
  (
    const int iArea,                  // Area(s) to observe
    const LogMessage::Level nLevel,   // Level to observe
    const Type nType                  // Observer's type 
  )
  : m_iArea(iArea), 
    m_nLevel(nLevel), 
    m_nType(nType),
    m_hLogSemaphore(INVALID_HANDLE_VALUE),
    m_bProcessQueueToEnd(false)
{
  m_hLogSemaphore = ::CreateSemaphore(NULL, 0, 0xfffffff, NULL);

  if (m_hLogSemaphore == NULL)
  {
    m_hLogSemaphore = INVALID_HANDLE_VALUE;
    throw (INVALID_HANDLE_VALUE);
  }
}

/**********************************************************************
*
* LogObserver::~LogObserver
*
* Description: Destructor
*
**********************************************************************/
LogObserver::~LogObserver()
{
  if (m_hLogSemaphore != INVALID_HANDLE_VALUE)
  {
    ::CloseHandle(m_hLogSemaphore);
    m_hLogSemaphore = INVALID_HANDLE_VALUE;
  }
}

/**********************************************************************
*
* LogObserver::SetProcessQueueToEnd
*
* Description: Sets the value of m_bProcessQueueToEnd; thread safe
*
**********************************************************************/
void LogObserver::SetProcessQueueToEnd
  (
  const bool bProcessQueueToEnd /* = true */ // new value
  )
{
  ::EnterCriticalSection(&GetCriticalSection());

  m_bProcessQueueToEnd = bProcessQueueToEnd;

  ::LeaveCriticalSection(&GetCriticalSection());
}

/**********************************************************************
*
* LogObserver::GetProcessQueueToEnd
*
* Description: Returns the value of m_bProcessQueueToEnd; thread safe
*
* Returns: bool
*   true: MessageQueue shall be procecced when finishing
*   false: MessageQueue shall not be procecced when finishing
*
**********************************************************************/
bool LogObserver::GetProcessQueueToEnd()
{
  bool bRet;

  ::EnterCriticalSection(&GetCriticalSection());

  bRet = m_bProcessQueueToEnd;

  ::LeaveCriticalSection(&GetCriticalSection());

  return (bRet);
}

/**********************************************************************
*
* LogObserver::Operation
*
* Description: Do the theads job here. To stop it, call End(false);  
*
**********************************************************************/
void LogObserver::Operation()
{
  switch(::WaitForSingleObject(m_hLogSemaphore, INFINITE))
  {
    case WAIT_OBJECT_0:
      {
        LogMessage oMessage(m_oMessageQueue.GetMessage());
        if (oMessage.GetArea() == LogMessage::evLogInternal)
        {
          if (oMessage.GetLogInternals() == LogMessage::evEnd)
          {
            End(false);
            break;
          }
        }
        else
        {
          Write(oMessage);
        }
        break;
      }
    default:
      break;
  }
}
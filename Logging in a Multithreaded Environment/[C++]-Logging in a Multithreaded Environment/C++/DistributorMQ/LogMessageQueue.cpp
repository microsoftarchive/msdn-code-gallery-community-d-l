/**********************************************************************
*
* LogMessageQueue.h: Declaration of LogMessageQueue
*
* A thread safe LogMessage queue based on std::queue
*
* Comment: This class is intentionally not derived from std::queue to prevent
*   thread unsafe queue access.
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#include "stdafx.h"
#include "LogMessageQueue.h"

/**********************************************************************
*
* LogMessageQueue::LogMessageQueue
*
* Description: Constructor
*
* Exceptions: ::InitializeCriticalSection might throw STATUS_NO_MEMORY,
*   which is not caught here.
*
**********************************************************************/
LogMessageQueue::LogMessageQueue()
  : m_bCriticalSectionInitialized(false)
{
  ::InitializeCriticalSection(&m_CriticalSection);

  m_bCriticalSectionInitialized = true;
}

/**********************************************************************
*
* LogMessageQueue::~LogMessageQueue
*
* Description: Destructor
*
**********************************************************************/
LogMessageQueue::~LogMessageQueue()
{
  printf("QueueSize: %ld\n", m_Queue.size());

  if (m_bCriticalSectionInitialized)
  {
    ::DeleteCriticalSection(&m_CriticalSection);
    m_bCriticalSectionInitialized = false;
  }
}

/**********************************************************************
*
* LogMessageQueue::operator+=
*
* Description: Adds a LogMessage into the queue, thread safe
*
**********************************************************************/
void LogMessageQueue::operator+=
  (
  const LogMessage & rLogMessage // Message to add
  )
{
  ::EnterCriticalSection(&m_CriticalSection);

  m_Queue.push(rLogMessage);

  ::LeaveCriticalSection(&m_CriticalSection);
}

/**********************************************************************
*
* LogMessageQueue::GetMessage
*
* Description: Get the first message and remove it from the queue; thread safe
*
* Returns: LogMessage
*   The first message of the queue
*
**********************************************************************/
LogMessage LogMessageQueue::GetMessage()
{
  LogMessage oRet(LogMessage::evAll, LogMessage::evError, 
                    "No LogMessage in the queue");

  ::EnterCriticalSection(&m_CriticalSection);

  if (m_Queue.empty())
  {
    ASSERT(FALSE); // This sould never happen!
  }
  else
  {
    oRet = m_Queue.front();
    m_Queue.pop();
  }

  ::LeaveCriticalSection(&m_CriticalSection);

  return (oRet);
}

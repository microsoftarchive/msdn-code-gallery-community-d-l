/**********************************************************************
*
* LogDistributor.cpp: Definition of LogDistributor
*
* The log message distributor
*
* Comment: This class is implemented as a singleton
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#include "stdafx.h"
#include "LogDistributor.h"
#include "LogObserver.h"

#include <algorithm>
#include <functional>

/**********************************************************************
*
* LogDistributor::Instance
*
* Description: Returns the reference to the one and only distributor
*
* Returns: LogDistributor &
*   Reference to the one and only distributor
*
**********************************************************************/
LogDistributor & LogDistributor::Instance()
{
  static LogDistributor instance;

  return (instance);
}

/**********************************************************************
*
* LogDistributor::~LogDistributor
*
* Description: Destructor
*
**********************************************************************/
LogDistributor::~LogDistributor()
{
  // Free the log semaphore
  if (m_hLogSemaphore != INVALID_HANDLE_VALUE)
  {
    ::CloseHandle(m_hLogSemaphore);
    m_hLogSemaphore = INVALID_HANDLE_VALUE;
  }

  // If there is no critical section, the vector containing the observers
  // cannot be handled too.
  if (!m_bCriticalSectionInitialized)
  {
    ASSERT(m_vecObserver.empty()); // there shouldn't exist any more observer
    return;
  }

  // Free all observers
  while(!m_vecObserver.empty())
    *this -= *(m_vecObserver.begin());

  ::DeleteCriticalSection(&m_CriticalSection);

  m_bCriticalSectionInitialized = false;
}

/**********************************************************************
*
* LogDistributor::Initialize
*
* Description: Init the critical section and create the log semaphore
*
* Returns: LogDistributor &
*   Reference to the one and only dispatcher
*
* Exceptions: ::InitializeCriticalSection might throw STATUS_NO_MEMORY,
*   which is not caught here.
*   INVALID_HANDLE_VALUE if the log semaphore could not be created
*
**********************************************************************/
LogDistributor & LogDistributor::Initialize()
{
  ::InitializeCriticalSection(&m_CriticalSection);

  m_bCriticalSectionInitialized = true;

  m_hLogSemaphore = ::CreateSemaphore(NULL, 0, 0xfffffff, NULL);

  if (m_hLogSemaphore == NULL)
  {
    m_hLogSemaphore = INVALID_HANDLE_VALUE;
    throw (INVALID_HANDLE_VALUE);
  }

  return (*this);
}

/**********************************************************************
*
* LogDistributor::operator+=
*
* Description: Adds an observer to the list and starts it
*
**********************************************************************/
void LogDistributor::operator+=
  (
  LogObserver * pObserver // Observer to add
  )
{
  bool bStartObserver = false;

  ::EnterCriticalSection(&m_CriticalSection);

  itObserverVector itEnd = m_vecObserver.end();
  itObserverVector it = std::find(m_vecObserver.begin(), itEnd, pObserver);

  // Only add Observer not in the vector
  if (it != itEnd)
    goto OperatorAddEqualsEnd;

  m_vecObserver.push_back(pObserver);

  bStartObserver = true;

OperatorAddEqualsEnd:
  ::LeaveCriticalSection(&m_CriticalSection);

  if (bStartObserver)
    pObserver->Start();
}

/**********************************************************************
*
* LogDistributor::operator-=
*
* Description: Removes an observer from the list, stops it, and frees 
*   its allocated memory
*
**********************************************************************/
void LogDistributor::operator-=
  (
  const LogObserver * pObserver // Observer to remove
  )
{
  LogObserver * pObserverToStop = 0L;

  ::EnterCriticalSection(&m_CriticalSection);

  itObserverVector itEnd = m_vecObserver.end();
  itObserverVector it = std::find(m_vecObserver.begin(), itEnd, pObserver);

  if (it != itEnd)
  {
    pObserverToStop = *it;
    m_vecObserver.erase(it);
  }

  ::LeaveCriticalSection(&m_CriticalSection);

  // Observer is not in the list
  if (!pObserverToStop)
    return;

  // Set a internal message the thread should end
  pObserverToStop->AddMessage(LogMessage(LogMessage::evLogInternal,
                                         LogMessage::evEvent, "", 
                                         LogMessage::evEnd));
  
  // Semaphore must be set, even if the observer's message queue
  // should be proceeded!
  ::ReleaseSemaphore(pObserverToStop->GetSemaphoreHandle(), 1L, NULL);

  // Proceed the message queue or stop immidiately
  pObserverToStop->GetProcessQueueToEnd()
    ? ::WaitForSingleObject(pObserverToStop->Handle(), INFINITE)
      : pObserverToStop->End(true);

  delete pObserverToStop;
}

/**********************************************************************
*
* LogDistributor::Log
*
* Description: Adds a LogMessage to the distributor's message queue
*
**********************************************************************/
void LogDistributor::Log
  (
  const LogMessage & rMessage // Message to log
  )
{
  m_oMessageQueue += rMessage;

  ::ReleaseSemaphore(m_hLogSemaphore, 1L, NULL);
}

/**********************************************************************
*
* LogDistributor::Operation
*
* Description: Waits until a LogMessage was added as passed it to 
*   the logger's message queue
*
**********************************************************************/
void LogDistributor::Operation()
{
  // Get a chance to stop the thread
  if (::WaitForSingleObject(m_hLogSemaphore, evWaitTimeout) != WAIT_OBJECT_0)
    return;

  LogMessage message(m_oMessageQueue.GetMessage());

  ::EnterCriticalSection(&m_CriticalSection);

  std::for_each(m_vecObserver.begin(), m_vecObserver.end(),
                std::bind2nd(CreateLogEntry(), message));

  ::LeaveCriticalSection(&m_CriticalSection);
}
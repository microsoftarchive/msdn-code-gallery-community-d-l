/**********************************************************************
*
* ThreadBase.cpp: Implementation of ThreadBase
*
* Thread base class
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#include "StdAfx.h"
#include "ThreadBase.h"
#include <process.h>

/**********************************************************************
*
* ThreadBase::ThreadBase
*
* Description: Constructor
*
* Exceptions: ::InitializeCriticalSection might throw STATUS_NO_MEMOTY,
*   which is not caught here.
*
**********************************************************************/
ThreadBase::ThreadBase()
  : m_uThreadId(0),
    m_hThread(INVALID_HANDLE_VALUE),
    m_bContinue(true),
    m_bCriticalSectionInitialized(false)
{
  ::InitializeCriticalSection(&m_CriticalSection);

  m_bCriticalSectionInitialized = true;
}

/**********************************************************************
*
* ThreadBase::CleanUp
*
* Description: Free all system resources
*
**********************************************************************/
void ThreadBase::CleanUp
  (
  const bool bDeleteCriticalSection // release the CriticalSection
  )
{
  if (m_bCriticalSectionInitialized && bDeleteCriticalSection)
  {
    ::DeleteCriticalSection(&m_CriticalSection);
    m_bCriticalSectionInitialized = false;
  }

  if (m_hThread != INVALID_HANDLE_VALUE)
  {
    ::CloseHandle(m_hThread);
    m_hThread = INVALID_HANDLE_VALUE;
  }

  m_uThreadId = 0;
}

/**********************************************************************
*
* ThreadBase::Handle
*
* Description: Returns the thread's handle; thread safe
*
* Returns: HANDLE
*   Handle of this thread
*
**********************************************************************/
HANDLE ThreadBase::Handle() 
{
  HANDLE hRet;

  ::EnterCriticalSection(&m_CriticalSection);

  hRet = m_hThread;

  ::LeaveCriticalSection(&m_CriticalSection);

  return (m_hThread);
}

/**********************************************************************
*
* ThreadBase::Run
*
* Description: The opeartion loop
*
* Returns: int
*   always 0
*
* Comment: First, PreOperation() is call to give the derived class the 
*   ability to do some initializations inside the thread. Operation()
*   is called as long as the continue flag of the thread is true.
*   PostOperation() offers the ability to do some thread finalizations.
*
**********************************************************************/
int ThreadBase::Run()
{
	if (!PreOperation())
  {
    PostOperation();
    return (-1);
  }

	while (GetContinue())
		Operation();

	PostOperation();

	return (0);
}

/**********************************************************************
*
* ThreadBase::Start
*
* Description: Starts the new thread
*
**********************************************************************/
void ThreadBase::Start
  (
  const int iPriority /* = THREAD_PRIORITY_NORMAL */ // Priority of the new thread
  )
{
  End(true);

  SetContinue(true);

	m_hThread 
    = reinterpret_cast<HANDLE> (::_beginthreadex(NULL, 0, ThreadBase::RunProc, this, 1, 
                                                 &m_uThreadId));

  if (m_hThread != INVALID_HANDLE_VALUE)
    ::SetThreadPriority(m_hThread, iPriority);
}

/**********************************************************************
*
* ThreadBase::End
*
* Description: Tells the thread to stop
*
**********************************************************************/
void ThreadBase::End
  (
  const bool bCalledFromOutside // Called from outside of the thread or by the thread itself
  )
{
  if (m_hThread == INVALID_HANDLE_VALUE)
    return;

	SetContinue(false);

  // The thread cannot wait for itself when stopping. Also, CleanUp cannot be called
  // while the thread itself has not finished.
  if (!bCalledFromOutside)
    return;

	::WaitForSingleObject(m_hThread, INFINITE);

  // Free resources as soon as possible
  CleanUp(false);
}

/**********************************************************************
*
* ThreadBase::GetContinue
*
* Description: Returns the value of the continue flag; thread safe
*
* Returns: bool
*   true: Thread shall continue
*   false: Thread shall not continue
*
* Exceptions: ::EnterCriticalSection might throw STATUS_INVALID_HANDLE
*   in low memory situations, which is not handled here.
*
**********************************************************************/
bool ThreadBase::GetContinue()
{
	bool bRet;

  ::EnterCriticalSection(&m_CriticalSection);

	bRet = m_bContinue;

  ::LeaveCriticalSection(&m_CriticalSection);

	return (bRet);
}

/**********************************************************************
*
* ThreadBase::SetContinue
*
* Description: Sets the continue flag; thread safe
*
* Exceptions: ::EnterCriticalSection might throw STATUS_INVALID_HANDLE
*   in low memory situations, which is not handled here.
*
**********************************************************************/
void ThreadBase::SetContinue
  (
  const bool bContinue // Value to set
  )
{
  ::EnterCriticalSection(&m_CriticalSection);

	m_bContinue = bContinue;

  ::LeaveCriticalSection(&m_CriticalSection);
}


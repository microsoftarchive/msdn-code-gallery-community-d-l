/**********************************************************************
*
* ThreadBase.h: Definition of ThreadBase
*
* Thread base class
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#ifndef _THREADBASE_H_
#define _THREADBASE_H_

#if _MSC_VER > 1000
#pragma once
#endif

class ThreadBase
{
public: 
  // Thread function, passed to _beginthreadex when creating the thread
	static unsigned int __stdcall RunProc
    ( 
    void * pParameter // Parameter of this method, here pointer to the class' instance
    )
  { return (static_cast<ThreadBase *>(pParameter)->Run()); }

public:
  // Constrcutor
	ThreadBase();

  // Destructor
  virtual ~ThreadBase() { CleanUp(true); }

  // Returns the thread's handle; thread safe
  HANDLE Handle();

  // Starts the new thread
	void Start
    (
    const int iPriority = THREAD_PRIORITY_NORMAL // Priority of the new thread
    );

  // Tells the thread to stop
  void End
    (
    const bool bCalledFromOutside // Called from outside of the thread or by the thread itself?
    );

protected:
  // Thread initialization
  virtual bool PreOperation() { return (true); }

  // Do the thead's job here. To stop it, call End(false);
	virtual void Operation() = 0; 

  // Thread finalization
	virtual void PostOperation() {}

  // Reference to the thread's CriticalSection
  CRITICAL_SECTION & GetCriticalSection() { return (m_CriticalSection); }

private:
  // Not implemented
  ThreadBase(const ThreadBase & src);
  // Not implemented
  ThreadBase & operator=(const ThreadBase & src);

  // The opeartion loop
 	int Run();

  // Sets the continue flag; thread safe
 	void SetContinue
    (
    const bool val // Value to set
    );

  // Returns the value of the continue flag; thread safe
	bool GetContinue();

  // Free all system resources
  void CleanUp
    (
    const bool bDeleteCriticalSection // release the CriticalSection
    );

  // ThreadId, set by _beginthreadex
  unsigned m_uThreadId;

  // Handle of the thread
  HANDLE m_hThread;

  // Shall the thread continue to run
	bool m_bContinue;

  // Was the Critical Section initialized
  bool m_bCriticalSectionInitialized;

  // Critical Section for thread safe operations
  CRITICAL_SECTION m_CriticalSection; 
};

#endif // _THREADBASE_H_
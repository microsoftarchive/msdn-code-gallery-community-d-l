/**********************************************************************
*
* LoggerThread.h: Declaration of LoggerThread
*
* Thread to generate log messages
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#ifndef _LOGGERTHREAD_H_
#define _LOGGERTHREAD_H_

#include "ThreadBase.h"

class LoggerThread : public ThreadBase
{
public:
  // Constructor
  LoggerThread() 
    : m_sTimeMultiplcator(++m_ssTimeMultiplcator),
      m_lMessageNo(0L)
  { }

protected:
  // Thread initialization
  virtual bool PreOperation() 
  { m_dwThreadId = ::GetCurrentThreadId(); return (true); }

  // Do the thead's job here. To stop it, call End(false);
	virtual void Operation(); 

private:
  // Not implemented
  LoggerThread(const LoggerThread & rSrc);
  // Not implemented
  LoggerThread & operator=(const LoggerThread & rSrc);

  // Multiplicator of the sleep time between generating a new message
  static short m_ssTimeMultiplcator;

  // Multiplicator of the sleep time between generating a new message
  const short m_sTimeMultiplcator;

  // Number of the generated messages
  long m_lMessageNo;

  // Id of the thread
  DWORD m_dwThreadId;
};

#endif // _LOGGERTHREAD_H_
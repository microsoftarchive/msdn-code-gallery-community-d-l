/**********************************************************************
*
* LogObserver.h: Declaration of LogObserver
*
* The LogObserver base class
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#ifndef _LOGOBSERVER_H_
#define _LOGOBSERVER_H_

#include "ThreadBase.h"
#include "LogMessage.h"
#include "LogMessageQueue.h"

class LogObserver : public ThreadBase
{
public:
  enum Type { Console, Window, File };

  // Destructor
  virtual ~LogObserver();

  // Returns the area(s) to observe
  int GetArea() const { return (m_iArea); }

  // Returns the level to observe
  LogMessage::Level GetLevel() const { return (m_nLevel); }

  // Returns the observer's type
  Type GetType() const { return (m_nType); }

  // Adds a message to the message queue; thread safe
  LogObserver & AddMessage(const LogMessage & rMessage)
  { m_oMessageQueue += rMessage; return (*this); }

  // Returns the handle to the (log message) semaphore
  HANDLE GetSemaphoreHandle() const { return (m_hLogSemaphore); }

  // Sets the value of m_bProcessQueueToEnd; thread safe
  void SetProcessQueueToEnd
    (
    const bool bProcessQueueToEnd = true // new value
    );

  // Returns the value of m_bProcessQueueToEnd; thread safe
  bool GetProcessQueueToEnd();

protected:
  // Constructor
  LogObserver
    (
    const int iArea,                  // Area(s) to observe
    const LogMessage::Level nLevel,   // Level to observe
    const Type nType                  // Observer's type 
    );

  // Thread initialization
  virtual bool PreOperation() { return (true); }

  // Do the thead's job here. To stop it, call End(false);  
  virtual void Operation();

  // Writes the Log-Message
  virtual void Write(const LogMessage & rMessage) = 0;

private:
  // Not implemented
  LogObserver(const LogObserver & rSrc);
  // Not implemented
  LogObserver & operator=(const LogObserver & rSrc);

  // Area(s) to observe
  const int m_iArea;

  // Level to observe
  const LogMessage::Level m_nLevel;

  // Observer's type
  const Type m_nType;

  // Thread safe queue of all messages to report
  LogMessageQueue m_oMessageQueue;

  // Handle of the log semaphore
  HANDLE m_hLogSemaphore;

  // Shall the distributor finish the observer's queue when the observer terminates?
  // (must be handled by the user)
  bool m_bProcessQueueToEnd;
};

#endif // _LOGOBSERVER_H_
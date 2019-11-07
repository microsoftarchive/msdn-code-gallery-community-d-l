/**********************************************************************
*
* LogObserver.h: Definition of LogObserver
*
* The LogObserver base class
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#ifndef _LOGOBSERVER_H_
#define _LOGOBSERVER_H_

#include "LogMessage.h"

class LogObserver
{
public:
  enum Type { Console, Window, File };

  // Constructor
  LogObserver
    (
    const int iArea,                  // Area(s) to observe
    const LogMessage::Level nLevel,   // Level to observe
    const Type nType                  // Observer type 
    ) 
    : m_iArea(iArea), m_nLevel(nLevel), m_nType(nType)
  { }

  // Destructor
  virtual ~LogObserver() { }

  // Writes the Log-Message
  virtual void Write(const LogMessage & rMessage) const = 0;

  // Returns the area(s) to observe
  int GetArea() const { return (m_iArea); }

  // Returns the level to observe
  LogMessage::Level GetLevel() const { return (m_nLevel); }

  // Returns the observer's type
  Type GetType() const { return (m_nType); }

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
};

#endif // _LOGOBSERVER_H_
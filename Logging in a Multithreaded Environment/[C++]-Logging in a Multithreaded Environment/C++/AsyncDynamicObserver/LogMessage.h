/**********************************************************************
*
* LogMessage.h: Definition of LogMessage
*
* The LogMessage class
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#ifndef _LOGMESSAGE_H_
#define _LOGMESSAGE_H_

#include <string>
#include <vector>

class LogMessage
{
public:
  enum Area    { evLogInternal=0, evGUI=1, evCom=2, evUserActivity=4, evAll=7 };
  enum Level   { evError, evEvent, evTrace, evDebug };
  enum LogInternals { evNoInternals, evEnd };

  // Constructor
  LogMessage
    (
    const Area nArea,                                 // The message area
    const Level nLevel,                               // The message level
    char * pszText,                                  // The message text
    const LogInternals nLogInternals = evNoInternals  // Log internals if nArea is evLogInternal
    ) 
    : m_nArea(nArea), m_nLevel(nLevel), m_strText(pszText), 
      m_nLogInternals(nLogInternals)
  { }

  // Constructor
  LogMessage
    (
    const Area nArea,                                 // The message area
    const Level nLevel,                               // The message level
    std::string & strText,                                  // The message text
    const LogInternals nLogInternals = evNoInternals  // Log internals if nArea is evLogInternal
    ) 
    : m_nArea(nArea), m_nLevel(nLevel), m_strText(strText), 
      m_nLogInternals(nLogInternals)
  { }

  // CopyCtor
  LogMessage
    (
    const LogMessage & rSrc // Message to copy
    )
    : m_nArea(rSrc.m_nArea), m_nLevel(rSrc.m_nLevel), m_strText(rSrc.m_strText),
      m_nLogInternals(rSrc.m_nLogInternals)
  { }

  // Assignment operator
  void operator=(const LogMessage & rSrc)
  { m_nArea = rSrc.m_nArea; m_nLevel = rSrc.m_nLevel; m_strText = rSrc.m_strText; 
    m_nLogInternals = rSrc.m_nLogInternals; }

  // Returns the message text
  std::string GetText() const { return (m_strText); }

  // Returns the message area
  Area GetArea() const { return (m_nArea); }

  // Returns the message level
  Level GetLevel() const { return (m_nLevel); }

  // Returns the value of log internal information
  LogInternals GetLogInternals() const { return (m_nLogInternals); }

private:
  // The text
  std::string m_strText;

  // The area
  Area m_nArea;

  // The level
  Level m_nLevel;

  // Only holds a valied value if m_nArea == evLogInternal
  LogInternals m_nLogInternals;
};

#endif // _LOGMESSAGE_H_
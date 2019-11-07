/**********************************************************************
*
* LogDistributor.cpp: Implementation of LogDistributor
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

/**********************************************************************
*
* LogDistributor::Instance
*
* Description: Returns the reference to the one and only distributor
*
* Returns: LogDistributor &
*   Reference to the one and only dispatcher
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
* Description: Destructor: Free all resources / observers
*
**********************************************************************/
LogDistributor::~LogDistributor()
{
  // Free all observers
  while(!m_vecObserver.empty())
    *this -= *(m_vecObserver.begin());
}

/**********************************************************************
*
* LogDistributor::operator+=
*
* Description: Adds an observer to the list
*
* Returns: Reference to itself
*
**********************************************************************/
LogDistributor & LogDistributor::operator+=
  (
  LogObserver * pObserver // Observer to add
  )
{
  itObserverVector itEnd = m_vecObserver.end();
  itObserverVector it = std::find(m_vecObserver.begin(), itEnd, pObserver);

  // Only add Observer not in the vector
  if (it == itEnd)
    m_vecObserver.push_back(pObserver);

  return (*this);
}

/**********************************************************************
*
* LogDistributor::operator-=
*
* Description: Removes an observer from the list and frees its allocated memory
*
* Returns: Reference to itself
*
**********************************************************************/
LogDistributor & LogDistributor::operator-=
  (
  const LogObserver * pObserver // Observer to remove
  )
{
  itObserverVector itEnd = m_vecObserver.end();
  itObserverVector it = std::find(m_vecObserver.begin(), itEnd, pObserver);

  // Observer not found?
  if (it == itEnd)
    return (*this);

  // Remove it from the vector
  m_vecObserver.erase(it);

  // Free the memory ('it' is invalid now)
  delete (pObserver);

  return (*this);
}

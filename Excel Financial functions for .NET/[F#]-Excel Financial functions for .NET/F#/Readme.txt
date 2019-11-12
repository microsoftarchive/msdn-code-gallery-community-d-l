What is it?
This is a .NET library that provides the full set of financial functions from Excel. The main goal for the library is compatibility with Excel, by providing the same functions, with the same behaviour. Note though that this is not a wrapper over the Excel library; the functions have been re-implemented in managed code so that you do not need to have Excel installed to use this library.

Where I can find documentation on these functions?
Just open Excel and click on Formulas/Financial or go to this link: http://office.microsoft.com/client/helppreview.aspx?AssetID=HP100791841033&ns=EXCEL&lcid=1033&CTT=3&Origin=HP100623561033

I don't think one of the function is right. Excel produces the wrong results! Why don't you do it right?
My goal is to replicate Excel results (right and wrong). Feel free to contribute to the effort by coding what you think is the right solution and I'll add an ExcelCompliant flag to the function to conditionally invoke your code.

How do I use the library?
Just add Financial.dll to the references in your project. The functions are provided as static methods on a Financial class in the System.Numeric namespace

I see the library was implemented with F#. But I don’t want to redistribute F# along with my application. What should I do?
There are two versions of the library. One of them statically links the F# libraries so that there is no dependency on F#. However, this assembly larger, so if you have F# installed, you can use the FinancialNotStandalone.dll instead.

How do I run the tests?
Run FinancialTests.exe. You need Excel 12 for the tests to work because they use Excel to test that the results are correct. You don't need Excel 12 to use the library in your own application.

How do I compile the library?
You need to have F# September CTP installed (you can get it from here http://www.microsoft.com/downloads/details.aspx?FamilyID=61ad6924-93ad-48dc-8c67-60f7e7803d3c). There are two batch files (CreateLibraryStandalone.bat and CreateLibraryNotStandalon.bat). Run them to compile the dll. You might have to change the path to the F# compiler inside these files

How do I compile the tests?
Run CreateTests.bat

Have you tested this thing?
Yes, I do have 201,349 testcases running against it. You can easily raise that number significantly by adding new values to test in testdef.fs. If you have a multiproc machine the testcases will run faster as I parallelize their execution.

Have you run performance tests on it?
Not at all. The only thing I checked is that all the recursive functions are tail recursive. Feel free to let me know if they are slow.

Are there any functions that behave different from Excel?
Yes, there are two of them.

CoupDays
The Excel algorithm seems wrong in that it doesn't respect the following:
coupDays = coupDaysBS + coupDaysNC.
This equality should stand. By manually counting the days, I'm pretty confident that my algorithm is correct.My result differs from Excel by +/- one or two days when the date spans a leap year.

VDB
In the excel version of this algorithm the depreciation in the period (0,1) is not the same as the sum of the depreciations in periods (0,0.5) (0.5,1).
VDB(100,10,13,0,0.5,1,0) + VDB(100,10,13,0.5,1,1,0) <> VDB(100,10,13,0,1,1,0)
Notice that in Excel by using '1' (no_switch) instead of '0' as the last parameter everything works as expected. The last parameter should have no influence in the calculation given that in the first period there is no switch to sln depreciation.
Overall, I think my algorithm is correct, even if it disagrees with Excel when startperiod is fractional.

Can you list the functions with their testcases results?
Succeeded 1840/1840 for PV
Succeeded 2024/2024 for FV
Succeeded 2240/2240 for PMT
Succeeded 853/853 for NPER
Succeeded 5355/5355 for IPMT
Succeeded 5355/5355 for PPMT
Succeeded 208/208 for CUMIPMT
Succeeded 208/208 for CUMPRINC
Succeeded 624/624 for ISPMT
Succeeded 12/12 for FVSCHEDULE
Succeeded 9/9 for IRR
Succeeded 21/21 for NPV
Succeeded 147/147 for MIRR
Succeeded 18/18 for XIRR
Succeeded 396/396 for DB
Succeeded 24/24 for SLN
Succeeded 132/132 for SYD
Succeeded 456/456 for DDB
Succeeded 2544/2544 for VDB excluding fractional startdates
Succeeded 11520/11520 for AMORLINC
Succeeded 23040/23040 for AMORDEGRC
Succeeded 15/15 for COUPDAYS excluding leap years
Succeeded 915/915 for COUPDAYSBS
Succeeded 915/915 for COUPDAYSNC
Succeeded 915/915 for COUPNUM
Succeeded 915/915 for COUPPCD
Succeeded 915/915 for COUPNCD
Succeeded 360/360 for ACCRINTM
Succeeded 1920/1920 for ACCRINT
Succeeded 10980/10980 for PRICE
Succeeded 1940/1940 for PRICEMAT
Succeeded 2910/2910 for YIELDMAT
Succeeded 1395/1395 for YEARFRAC
Succeeded 2745/2745 for INTRATE
Succeeded 1290/1290 for RECEIVED
Succeeded 2745/2745 for DISC
Succeeded 3660/3660 for PRICEDISC
Succeeded 2745/2745 for YIELDDISC
Succeeded 48/48 for TBILLEQ
Succeeded 69/69 for TBILLYIELD
Succeeded 81/81 for TBILLPrice
Succeeded 12/12 for DOLLARDE
Succeeded 12/12 for DOLLARFR
Succeeded 12/12 for EFFECT
Succeeded 12/12 for NOMINAL
Succeeded 5490/5490 for DURATION
Succeeded 5490/5490 for MDURATION
Succeeded 19320/19320 for ODDFPRICE
Succeeded 30600/30600 for ODDLPRICE
Succeeded 45900/45900 for ODDLYIELD
Test Cases Succeeded 201349/201349

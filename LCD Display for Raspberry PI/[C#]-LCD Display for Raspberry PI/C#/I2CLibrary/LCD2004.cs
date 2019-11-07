// ***********************************************************************
// Assembly         : I2CLibrary
// Author           : SH
// Created          : 04-14-2017
//
// Last Modified By : SH
// Last Modified On : 04-15-2017
// ***********************************************************************
// <copyright file="LCD2004.cs" company="http://www.heesch.net">
// Copyright © 2017 by Stefan Heesch
// </copyright>
// <summary>
// Library for using a SaintSmart LCD2004 display connected via I2C bus
// to an IoT device
// </summary>
// ***********************************************************************
using System;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.I2c;
using I2CLibrary.LCD2004;

#region  Hardwware Information
// Hardware connection
// ===================
//
// The LCD controller and the port expander are connected as show here:
//
// HD44780    -  PCF8574
// ------------------------
//        RS  -   P0
//        RW  -   P1
//        EN  -   P2
// BackLight  -   P3
//       DB4  -   P4
//       DB5  -   P5
//       DB6  -   P6
//       DB7  -   P7
#endregion


namespace I2CLibrary
{
    /// <summary>
    /// Represents a SaintSmart 2004 Liquid Chrystal Display
    /// 
    /// The SaintSmart 2004 LCD consists out of a standard 20x4 LCD Display with a
    /// HD44780 controller and a PCF8574t I2C port expander.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class Lcd2004 : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Lcd2004"/> class.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public Lcd2004()
        {
            _mDevice = null;
            _disposed = false;

        }


        /// <summary>
        /// Private handle to an I2C device object for communicating with the LCD2004 display over the I2C bus
        /// </summary>
        private I2cDevice _mDevice;

        #region IDisposable Support
        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            // dispose managed state(managed objects).
            if (disposing)
            {
                if (_mDevice != null) _mDevice.Dispose();
                _mDevice = null;
                System.Diagnostics.Debug.WriteLine($"I2C Address {I2CAddress} released.");
            }
            _disposed = true;
        }

        // This code added to correctly implement the disposable pattern.
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
       
        // 
        /// <summary>
        /// The Saintsmart LCD's I2C Address. This might be either 0x27 or 0x3F
        /// </summary>
        const int I2CAddress = 0x27;


        /// <summary>
        /// The display function
        /// </summary>
        private byte _displayFunction = FunctionSet.LCD_4BITMODE;
        /// <summary>
        /// The display control
        /// </summary>
        private byte _displayControl  = ControlSet.LCD_DISPLAYOFF;
        /// <summary>
        /// The display mode
        /// </summary>
        private byte _displayMode     = EntryMode.LCD_ENTRYLEFT | EntryMode.LCD_ENTRYSHIFTDECREMENT;
        /// <summary>
        /// The backlight
        /// </summary>
        private byte _backlight       = Backlight.LCD_BACKLIGHT_ON;


        /// <summary>
        /// The number of supported columns
        /// </summary>
        private int _columns;
        /// <summary>
        /// The number of supported rows
        /// </summary>
        private int _rows;

        /// <summary>
        /// Synchronous delay.
        /// </summary>
        /// <param name="milliseconds">Delay time in milliseconds.</param>
        private void Delay(int milliseconds)
        {
            Task.Delay(milliseconds).Wait();
        }

        /// <summary>
        /// Write4s the bits.
        /// </summary>
        /// <param name="bits">The bits.</param>
        /// <param name="mode">The mode.</param>
        private void Write4Bits(byte bits, byte mode = 0)
        {
            byte value = bits; 

            byte[] data  = { (byte) ( value | mode | _backlight             ) };
            byte[] pulse = { (byte) ( value | mode | _backlight | Pinout.EN ) };

            if (_mDevice != null)
            {
                _mDevice.Write(pulse);
                _mDevice.Write(data);
            }
        }


        /// <summary>
        /// Writes 8 bits, either to the command register or to the display memory.
        /// </summary>
        /// <param name="bits">The bits.</param>
        /// <param name="mode">The mode.</param>
        private void Write8Bits(byte bits, byte mode = 0)
        {
            byte highNibble = (byte) ( bits & 0xF0);
            byte lowNibble  = (byte) ((bits << 4) & 0xF0);

            Write4Bits(highNibble, mode );
            Write4Bits(lowNibble, mode  );
        }

        /// <summary>
        /// Initializes the LCD with number of supported columns and rows.
        /// </summary>
        /// <param name="cols">The number of columns.</param>
        /// <param name="rows">The number of rows.</param>
        /// <exception cref="System.Exception"></exception>
        public async void Initialize(int cols = 20, int rows = 4)
        {
            _rows = rows;
            _columns = cols;

            if (rows > 1) _displayFunction |= FunctionSet.LCD_2LINE;

            _backlight = Backlight.LCD_BACKLIGHT_ON;
            _displayControl = ControlSet.LCD_DISPLAYON | ControlSet.LCD_CURSOROFF | ControlSet.LCD_BLINKOFF;

            try
            {
                var i2CSettings = new I2cConnectionSettings(I2CAddress);
                i2CSettings.BusSpeed = I2cBusSpeed.FastMode;

                string i2CMaster = I2cDevice.GetDeviceSelector();

                var i2CSlaves = await DeviceInformation.FindAllAsync(i2CMaster);
                _mDevice = await I2cDevice.FromIdAsync(i2CSlaves[0].Id, i2CSettings);
                if (_mDevice == null)
                {
                    throw new Exception($"I2C Device with address {I2CAddress} already in use");
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception: {0}", e.Message);
                _mDevice = null;
                throw;
            }
            InitializeHardware();
        }

        /// <summary>
        /// Initializes the hardware.
        /// </summary>
        private void InitializeHardware()
        {
            if (_mDevice != null)
            {
                try
                {
                    byte[] data = {_backlight};
                    _mDevice.Write(data);

                    // put LCD into 4bit mode according to HD44780 datasheet page 46

                    Write4Bits( 0x03 << 4 );
                    Delay(4);
                    Write4Bits( 0x03 << 4 );
                    Delay(4);
                    Write4Bits( 0x03 << 4 );
                    Delay(1);

                    Write4Bits(0x02 <<4 );
                    Delay(1);

                    Write8Bits((byte)(Command.LCD_FUNCTIONSET    | _displayFunction ));
                    Delay(2);
                    Write8Bits((byte)(Command.LCD_DISPLAYCONTROL | _displayControl  ));
                    Delay(2);

                    Home();
                    Clear();

                    Write8Bits((byte) (Command.LCD_ENTRYMODESET | _displayMode));
                    Delay(2);

                }
                catch (Exception)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to initialize display on I2C address {0}", I2CAddress);
                    throw;
                }

            }
        }

        /// <summary>
        /// Clears the LCD.
        /// </summary>
        public void Clear()
        {
            if (_mDevice != null)
            {
                try
                { 
                    Write8Bits(Command.LCD_CLEARDISPLAY);
                    Delay(5);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("LCD command Clear() encountered an exception: {0}", e.Message);
                    throw;
                }
            }
        }

        /// <summary>
        /// Moves the cursor into the home position (column 0, row 0).
        /// </summary>
        public void Home()
        {
            if (_mDevice != null)
            {
                try
                {
                    Write8Bits(Command.LCD_RETURNHOME);
                    Delay(5);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("LCD command Home() encountered an exception: {0}", e.Message);
                    throw;
                }
            }
        }

        /// <summary>
        /// Enables or disables the LCD.
        /// </summary>
        /// <param name="enabled">if set to <c>true</c> [enabled], if set to <c>false</c> [disabled].</param>
        public void Display(bool enabled = true)
        {
            if (_mDevice != null)
            {
                try
                {
                    byte mode = ControlSet.LCD_DISPLAYON;
                    if (enabled)
                    {
                        _displayControl |= mode;
                    }
                    else
                    {
                        _displayControl &= (byte)~mode;
                    }
                    Write8Bits((byte)(Command.LCD_DISPLAYCONTROL | _displayControl));
                    Delay(1);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("LCD command Display() encountered an exception: {0}", e.Message);
                    throw;
                }
            }
        }

        /// <summary>
        /// Scrolls the display left.
        /// </summary>
        public void ScrollDisplayLeft()
        {
            if (_mDevice != null)
            {
                try
                {
                    Write8Bits( Command.LCD_CURSORSHIFT | DisplayMove.LCD_DISPLAYMOVE | DisplayMove.LCD_MOVELEFT);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("LCD command ScrollDisplayLeft() encountered an exception: {0}", e.Message);
                    throw;
                }
            }

        }

        /// <summary>
        /// Scrolls the display right.
        /// </summary>
        public void ScrollDisplayRight()
        {
            if (_mDevice != null)
            {
                try
                {
                    Write8Bits(Command.LCD_CURSORSHIFT | DisplayMove.LCD_DISPLAYMOVE | DisplayMove.LCD_MOVERIGHT);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("LCD command ScrollDisplayRight() encountered an exception: {0}", e.Message);
                    throw;
                }
            }
        }

        /// <summary>
        /// Sets the entry mode from left to right.
        /// </summary>
        public void LeftToRight()
        {
            if (_mDevice != null)
            {
                try
                {
                    byte mode = EntryMode.LCD_ENTRYLEFT;
                    _displayMode |= mode;
                    Write8Bits((byte)(Command.LCD_ENTRYMODESET | _displayMode));
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("LCD command LeftToRight() encountered an exception: {0}", e.Message);
                    throw;
                }
            }

        }

        /// <summary>
        /// Sets the entry mode from right to left.
        /// </summary>
        public void RightToLeft()
        {
            if (_mDevice != null)
            {
                try
                {
                    byte mode = EntryMode.LCD_ENTRYLEFT;
                    _displayMode &= (byte) ~mode;
                    Write8Bits((byte)(Command.LCD_ENTRYMODESET | _displayMode));
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("LCD command RightToLeft() encountered an exception: {0}", e.Message);
                    throw;
                }
            }
        }

        /// <summary>
        /// Automatic display scrolling is enabled or disabled.
        /// </summary>
        /// <param name="enabled">if set to <c>true</c> [enabled], if set to <c>false</c> [disabled]</param>
        public void AutoScroll(bool enabled)
        {
            if (_mDevice != null)
            {
                try
                {
                    byte mode = EntryMode.LCD_ENTRYSHIFTINCREMENT;
                    if (enabled)
                    {
                        _displayMode |= mode;
                    }
                    else
                    {
                        _displayMode &= (byte)~mode;
                    }
                    Write8Bits((byte)(Command.LCD_ENTRYMODESET | _displayMode));
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("LCD command AutoScroll() encountered an exception: {0}", e.Message);
                    throw;
                }
            }
        }

        /// <summary>
        /// Sets the cursor position.
        /// </summary>
        /// <param name="col">The column number (zero based).</param>
        /// <param name="row">The row number (zero based).</param>
        /// <exception cref="System.ArgumentException">
        /// SetCursor() - invalid parameter(column) is out of range
        /// or
        /// SetCursor() - invalid parameter(row) is out of range
        /// </exception>
        public void SetCursor(byte col, byte row)
        {
            if (col >= _columns) throw new ArgumentException("SetCursor() - invalid parameter", nameof(col) );
            if (row >= _rows) throw new ArgumentException("SetCursor() - invalid parameter", nameof(row));

            if (_mDevice != null)
            {
                byte[] offsets = { 0x00, 0x40, 0x14, 0x54 };
                {
                    try
                    {
                        Write8Bits( (byte) (Command.LCD_SETDDRAMADDR | col + offsets[row]) );
                        Delay(1);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine("LCD command SetCursor() encountered an exception: {0}", e.Message);
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Shows the line cursor when parameter is true, otherwise hides it.
        /// </summary>
        /// <param name="on">if set to <c>true</c> [shows line cursor] if set to <c>false</c> [hides line cursor].</param>
        public void LineCursor( bool on = true)
        {
            if (_mDevice != null)
            {
                try
                {
                    byte line = ControlSet.LCD_CURSORON;
                    if (on)
                    {
                        _displayControl |= line;
                    }
                    else
                    {
                        _displayControl &= (byte) ~line;
                    }
                    Write8Bits((byte)(Command.LCD_DISPLAYCONTROL | _displayControl));
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("LCD command LineCursor() encountered an exception: {0}", e.Message);
                    throw;
                }
            }
        }

        /// <summary>
        /// Shows the blinking cursor when parameter is true, otherwise hides it.
        /// </summary>
        /// <param name="on">if set to <c>true</c> [shows blinking cursor] if set to <c>false</c> [hides blinking cursor].</param>
        public void BlinkingCursor(bool on = true)
        {
            if (_mDevice != null)
            {
                try
                {
                    byte mode = ControlSet.LCD_BLINKON;
                    if (on)
                    {
                        _displayControl |= mode;
                    }
                    else
                    {
                        _displayControl &= (byte)~mode;
                    }
                    Write8Bits((byte)(Command.LCD_DISPLAYCONTROL | _displayControl));
                    Delay(1);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("LCD command BlinkingCursor() encountered an exception: {0}", e.Message);
                    throw;
                }
            }
        }

        /// <summary>
        /// Hides the blinking cursor and the line cursor.
        /// </summary>
        public void HideCursor()
        {
            if (_mDevice != null)
            {
                try
                {
                    byte mode = ControlSet.LCD_CURSORON;
                    _displayControl &= (byte)~mode;
                    byte hide = ControlSet.LCD_BLINKON;
                    _displayControl &= (byte)~hide;

                    Write8Bits((byte)(Command.LCD_DISPLAYCONTROL | _displayControl));
                    Delay(1);

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("LCD command HideCursor() encountered an exception: {0}", e.Message);
                    throw;
                }
            }
        }

        /// <summary>
        /// Switch the LCD back light [on] or [off].
        /// </summary>
        /// <param name="on">if set to <c>true</c> [on] if set to <c>false</c> [off].</param>
        public void BacklightOn(bool on)
        {
            if (_mDevice != null)
            {
                try
                {
                    if (on)
                    {
                        _backlight = Backlight.LCD_BACKLIGHT_ON;
                    }
                    else
                    {
                        _backlight = Backlight.LCD_BACKLIGHT_OFF;
                    }
                    Write4Bits(0);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("LCD command BacklightOn() encountered an exception: {0}", e.Message);
                    throw;
                }
            }
        }

        /// <summary>
        /// Prints the passed string onto the LCD display.
        /// </summary>
        /// <param name="data">String containing the print data.</param>
        public void Print(string data)
        {
            if (_mDevice != null)
            {
                try
                {
                    var bytes = Encoding.ASCII.GetBytes(data);
                    foreach (byte b in bytes)
                    {
                        Write8Bits( b , Pinout.RS );
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("LCD command Print() encountered an exception: {0}", e.Message);
                    throw;
                }
            }

        }

    }
}

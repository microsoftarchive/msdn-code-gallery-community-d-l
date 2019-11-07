using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FaceAPI_MVC.Web.Models
{
    public class vmFace
    {
        #region Fields

        /// <summary>
        /// Face gender text string
        /// </summary>
        private string _gender;

        /// <summary>
        /// Face age text string
        /// </summary>
        private string _age;

        /// <summary>
        /// Person name
        /// </summary>
        private string _personName;

        /// <summary>
        /// Face height in pixel
        /// </summary>
        private int _height;

        /// <summary>
        /// Face position X relative to image left-top in pixel
        /// </summary>
        private int _left;

        /// <summary>
        /// Face position Y relative to image left-top in pixel
        /// </summary>
        private int _top;

        /// <summary>
        /// Face width in pixel
        /// </summary>
        private int _width;

        /// <summary>
        /// Facial hair display string
        /// </summary>
        private string _facialHair;

        /// <summary>
        /// Indicates whether the face is smile or not
        /// </summary>
        private string _isSmiling;

        /// <summary>
        /// Indicates the glasses type
        /// </summary>
        private string _glasses;

        private string _fileName;
        private string _filePath;
        #endregion Fields

        #region Properties
        /// <summary>
        /// Gets or sets filename text string 
        /// </summary>
        public string FileName
        {
            get
            {
                return _fileName;
            }

            set
            {
                _fileName = value;
            }
        }

        /// <summary>
        /// Gets or sets filePath text string 
        /// </summary>
        public string FilePath
        {
            get
            {
                return _filePath;
            }

            set
            {
                _filePath = value;
            }
        }

        /// <summary>
        /// Gets or sets gender text string 
        /// </summary>
        public string Gender
        {
            get
            {
                return _gender;
            }

            set
            {
                _gender = value;
            }
        }

        /// <summary>
        /// Gets or sets age text string
        /// </summary>
        public string Age
        {
            get
            {
                return _age;
            }

            set
            {
                _age = value;
            }
        }

        /// <summary>
        /// Gets face rectangle on image
        /// </summary>
        //public System.Windows.Int32Rect UIRect
        //{
        //    get
        //    {
        //        return new System.Windows.Int32Rect(Left, Top, Width, Height);
        //    }
        //}

        /// <summary>
        /// Gets or sets image path
        /// </summary>
        public string ImagePath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets face id
        /// </summary>
        public string FaceId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets person's name
        /// </summary>
        public string PersonName
        {
            get
            {
                return _personName;
            }

            set
            {
                _personName = value;
            }
        }

        /// <summary>
        /// Gets or sets face height
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
            }
        }

        /// <summary>
        /// Gets or sets face position X
        /// </summary>
        public int Left
        {
            get
            {
                return _left;
            }

            set
            {
                _left = value;
            }
        }

        /// <summary>
        /// Gets or sets face position Y
        /// </summary>
        public int Top
        {
            get
            {
                return _top;
            }

            set
            {
                _top = value;
            }
        }

        /// <summary>
        /// Gets or sets face width
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }

        /// <summary>
        /// Gets or sets facial hair display string
        /// </summary>
        public string FacialHair
        {
            get
            {
                return _facialHair;
            }

            set
            {
                _facialHair = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the face is smile or not
        /// </summary>
        public string IsSmiling
        {
            get
            {
                return _isSmiling;
            }

            set
            {
                _isSmiling = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the glasses type 
        /// </summary>
        public string Glasses
        {
            get
            {
                return _glasses;
            }

            set
            {
                _glasses = value;
            }
        }

        #endregion Properties

        
    }
}
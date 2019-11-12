// Copyright 2016 gekka.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


//#define CS6

#region Directive and comment Test
#if CS
#if CS6
            // C# >= 6
#else
            // C# < 6
#endif
#elif VB
        /* VB */
#else
#pragma warning disable 67,162,168,169,219,414,429,649,661,1718
#endif
#pragma warning restore 67,162,168,169,219,414,429,649,661,1718
#endregion


using System;

namespace NameSpace
{
    //Comment E1
    /// <summary>Enum</summary>
    enum EnumE
    {
        //Comment E2
        /// <summary>EnumField</summary>
        None //Comment E3
        //Comment E4
    }
    //Comment S
    /// <summary>Struct</summary>
    struct StructS
    {
        //Comment S1
        public int Value; //Comment S2
        //Comment S3
    }

    /// <summary>
    /// XML Document Test
    /// </summary>
    class ClassC
    {
        //Comment C1
        /// <summary>
        /// Static Constructor
        /// </summary>
        static ClassC() { }//Comment C2
        //Comment C3

        //Comment C4
        /// <summary>summary</summary>
        /// <remarks>remarks</remarks>
        public ClassC() { }    //Comment C5
        //COmment C6

		//Comment C7
		/// <summary>Destructor</summary>
        ~ClassC(){}//Comment 8
		//Comment C9

        //Comment C10
        /// <summary>Property</summary>
        public int Property //Comment C11
        {
            //Comment C12
            get { return 0; }
            //Comment C13
            set { }
            //Comment C14
        } //Comment C15
        //Comment C16

		//Comment C17
		/// <summary>Field</summary>
        public int Field=0;//Comment C18
        //Comment C19

        //Comment C20
        /// <summary>Event</summary>
        event EventHandler<EventArgs> Event = delegate { };//Comment C21
        //Comment C22

        //Comment C23
		/// <summary>Delegate</summary>
        public delegate void Delegate();//Comment C24
        //Comment C25

		// Comment C26
		/// <summary>Method</summary>
        public void TestMethod(){}//Comment C27
		//Comment C28

		//Comment C29
		/// <summary>Function</summary>
		/// <returns></returns>
        public int TestFunction()//Comment C30
        {//F0
			//F1
            int i = 0+1;//F2
			//F3
            Func<int> a = () =>
            {
                //F4
                return 0; //F5
                //F6
            };//F7
			//F8

			//F9
            if (true)//F10
            {//F11
                //F12
                int xx = 0;//F13
                //F14
            }//F15
            else if(true) //F16
            {//F17
                //F18
                int yy = 0;//F19
                //F20
            }//F21
            else//F22
            {//F23
                //F24
                for (int j = 0; j < 1; j++)//F25
                {//26
                    //F27
                    foreach (int k in new int[] { 1})//F28
                    {//F29
                        //F30
                        while (true) //F31
                        {//32
							//F33
                            do //F34
                            {//F35
                                //F36
                                switch (0) //F37
                                {//F38
									//F39
								case 0://F40
                                    //F41
                                    goto case 1;//F42
                                case 1://43
									//F43
                                    break;//F45
                                default://F46
                                    //F47
                                    break;//F48
									//F49
                                }//50
								//F51
                                break;//F52
								//F53
                            }//F54
                            while (false);//F55
                            //56
                            break;//57
                            //F58
                        }//59
                        //F60
                    }//61
                    //F62
                }//63
				//F64
            }//65

			//F66
            {//67
				//F68
                int x = a() + i;//F69
				//F70
            }//71
			//F72
            return 0;//F73
			//F74
        }//75
		//Comment C31
    }
}




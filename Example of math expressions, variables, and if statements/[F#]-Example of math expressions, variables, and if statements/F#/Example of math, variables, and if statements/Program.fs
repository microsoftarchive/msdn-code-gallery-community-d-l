namespace Example_of_math__variables__and_if_statements
open System
open System.Drawing
open System.Windows.Forms
open System.Reflection

type Form1() as this =
    inherit Form()
    let icon = new Icon(Assembly.GetExecutingAssembly().GetManifestResourceStream("icon.ico"))
    let yes = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("yes.bmp"))
    let no = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("no.bmp"))
    let file = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("file.bmp"))
    let textBox1 = new TextBox()
    do textBox1.Location <- new Point(36, 10) //This creates textbox
    do textBox1.Name <- "textBox1"
    do textBox1.Size <- Size(100, 20)
    do textBox1.TabIndex <- 0
    let textBox2 = new TextBox()
    do textBox2.Location <- new Point(36, 28)
    do textBox2.Name <- "textBox2"
    do textBox2.Size <- Size(100, 20)
    do textBox2.TabIndex <- 1
    let label1 = new Label() //This creates a label
    do label1.AutoSize <- true
    do label1.Location <- new Point(12, 13)
    do label1.Name <- "label1"
    do label1.Size <- new Size(14, 13)
    do label1.TabIndex <- 2
    do label1.Text <- "X"
    let label2 = new Label()
    do label2.AutoSize <- true
    do label2.Location <- new Point(12, 28)
    do label2.Name <- "label2"
    do label2.Size <- new Size(14, 13)
    do label2.TabIndex <- 3
    do label2.Text <- "Y"
    let radioButton1 = new RadioButton() //This creates the first radiobutton in the group
    do radioButton1.AutoSize <- true
    do radioButton1.Location <- Point(3, 5)
    do radioButton1.Name <- "radioButton1"
    do radioButton1.Size <- Size(44, 17)
    do radioButton1.TabIndex <- 4
    do radioButton1.TabStop <- true
    do radioButton1.Text <-"Add\r\n"
    do radioButton1.UseVisualStyleBackColor <- true
    do radioButton1.CheckedChanged.Add(fun _ -> this.radioButton1_CheckChanged())
    let radioButton2 = new RadioButton()
    do radioButton2.AutoSize <- true
    do radioButton2.Location <- Point(3, 28)
    do radioButton2.Name <- "radioButton2"
    do radioButton2.Size <- Size(44, 17)
    do radioButton2.TabIndex <- 5
    do radioButton2.TabStop <- true
    do radioButton2.Text <-"Sub"
    do radioButton2.UseVisualStyleBackColor <- true
    do radioButton2.CheckedChanged.Add(fun _ -> this.radioButton2_CheckChanged())
    let radioButton3 = new RadioButton()
    do radioButton3.AutoSize <- true
    do radioButton3.Location <- Point(3, 74)
    do radioButton3.Name <- "radioButton3"
    do radioButton3.Size <- Size(41, 17)
    do radioButton3.TabIndex <- 6
    do radioButton3.TabStop <- true
    do radioButton3.Text <-"Div"
    do radioButton3.UseVisualStyleBackColor <- true
    do radioButton3.CheckedChanged.Add(fun _ -> this.radioButton3_CheckChanged())
    let radioButton4 = new RadioButton()
    do radioButton4.AutoSize <- true
    do radioButton4.Location <- Point(3, 51)
    do radioButton4.Name <- "radioButton4"
    do radioButton4.Size <- Size(42, 17)
    do radioButton4.TabIndex <- 7
    do radioButton4.TabStop <- true
    do radioButton4.Text <-"Mul"
    do radioButton4.UseVisualStyleBackColor <- true
    do radioButton4.CheckedChanged.Add(fun _ -> this.radioButton4_CheckChanged())
    let radioButton5 = new RadioButton()
    do radioButton5.AutoSize <- true
    do radioButton5.Location <- Point(28, 65)
    do radioButton5.Name <- "radioButton5"
    do radioButton5.Size <- Size(130, 17)
    do radioButton5.TabIndex <- 8
    do radioButton5.TabStop <- true
    do radioButton5.Text <-"Greater Than or Equal"
    do radioButton5.UseVisualStyleBackColor <- true
    do radioButton5.CheckedChanged.Add(fun _ -> this.radioButton5_CheckChanged())
    let radioButton6 = new RadioButton()
    do radioButton6.AutoSize <- true
    do radioButton6.Location <- Point(28, 42)
    do radioButton6.Name <- "radioButton6"
    do radioButton6.Size <- Size(75, 17)
    do radioButton6.TabIndex <- 9
    do radioButton6.TabStop <- true
    do radioButton6.Text <-"Less Than"
    do radioButton6.UseVisualStyleBackColor <- true
    do radioButton6.CheckedChanged.Add(fun _ -> this.radioButton6_CheckChanged())
    let radioButton7 = new RadioButton()
    do radioButton7.AutoSize <- true
    do radioButton7.Location <- Point(28, -2)
    do radioButton7.Name <- "radioButton7"
    do radioButton7.Size <- Size(52, 17)
    do radioButton7.TabIndex <- 10
    do radioButton7.TabStop <- true
    do radioButton7.Text <-"Equal"
    do radioButton7.UseVisualStyleBackColor <- true
    do radioButton7.CheckedChanged.Add(fun _ -> this.radioButton7_CheckChanged())
    let radioButton8 = new RadioButton()
    do radioButton8.AutoSize <- true
    do radioButton8.Location <- Point(28, 19)
    do radioButton8.Name <- "radioButton8"
    do radioButton8.Size <- Size(88, 17)
    do radioButton8.TabIndex <- 11
    do radioButton8.TabStop <- true
    do radioButton8.Text <-"Greater Than"
    do radioButton8.UseVisualStyleBackColor <- true
    do radioButton8.CheckedChanged.Add(fun _ -> this.radioButton8_CheckChanged())
    let radioButton9 = new RadioButton()
    do radioButton9.AutoSize <- true
    do radioButton9.Location <- Point(28, 88)
    do radioButton9.Name <- "radioButton9"
    do radioButton9.Size <- Size(117, 17)
    do radioButton9.TabIndex <- 12
    do radioButton9.TabStop <- true
    do radioButton9.Text <-"Less Than or Equal"
    do radioButton9.UseVisualStyleBackColor <- true
    do radioButton9.CheckedChanged.Add(fun _ -> this.radioButton9_CheckChanged())
    let radioButton10 = new RadioButton()
    do radioButton10.AutoSize <- true
    do radioButton10.Location <- Point(28, 107)
    do radioButton10.Name <- "radioButton10"
    do radioButton10.Size <- Size(72, 17)
    do radioButton10.TabIndex <- 13
    do radioButton10.TabStop <- true
    do radioButton10.Text <-"Not Equal"
    do radioButton10.UseVisualStyleBackColor <- true
    do radioButton10.CheckedChanged.Add(fun _ -> this.radioButton10_CheckChanged())
    let pictureBox1 = new PictureBox()
    do pictureBox1.ImageLocation <- ""
    do pictureBox1.Location <- Point(271, 10)
    do pictureBox1.Name <- "pictureBox1"
    do pictureBox1.Size <- Size(90, 35)
    do pictureBox1.TabIndex <- 14
    do pictureBox1.TabStop <- false
    let label3 = new Label()
    do label3.AutoSize <- true
    do label3.Location <- new Point(33, 53)
    do label3.Name <- "label3"
    do label3.Size <- new Size(42, 13)
    do label3.TabIndex <- 15
    do label3.Text <- "Answer"
    let groupBox1 = new GroupBox()
    do groupBox1.Controls.Add(radioButton1)
    do groupBox1.Controls.Add(radioButton2)
    do groupBox1.Controls.Add(radioButton4)
    do groupBox1.Controls.Add(radioButton3)
    do groupBox1.Location <- new Point(12, 69)
    do groupBox1.Name <- "groupBox1"
    do groupBox1.Size <- new Size(200, 100)
    do groupBox1.TabIndex <- 16
    do groupBox1.TabStop <- false
    let groupBox2 = new GroupBox()
    do groupBox2.Controls.Add(radioButton7)
    do groupBox2.Controls.Add(radioButton8)
    do groupBox2.Controls.Add(radioButton10)
    do groupBox2.Controls.Add(radioButton6)
    do groupBox2.Controls.Add(radioButton9)
    do groupBox2.Controls.Add(radioButton5)
    do groupBox2.Location <- new Point(243, 53)
    do groupBox2.Name <- "groupBox2"
    do groupBox2.Size <- new Size(200, 130)
    do groupBox2.TabIndex <- 0
    do groupBox2.TabStop <- false
    do this.AutoScaleDimensions <- SizeF((float32)0x6F, (float32)0x13F)
    do this.AutoScaleMode <- AutoScaleMode.Font
    do this.ClientSize <- Size(518, 272)
    do this.Controls.Add(label3)
    do this.Controls.Add(pictureBox1)
    do this.Controls.Add(label2)
    do this.Controls.Add(label1)
    do this.Controls.Add(textBox2)
    do this.Controls.Add(textBox1)
    do this.Controls.Add(groupBox1)
    do this.Controls.Add(groupBox2)
    do this.Icon <- icon
    do this.Name <- "Form1"
    do this.Text <- "Example of math, variables, and if statements"
    do groupBox1.ResumeLayout(false)
    do groupBox1.PerformLayout()
    do groupBox2.ResumeLayout(false)
    do groupBox2.PerformLayout()
    do this.ResumeLayout(false)
    do this.PerformLayout()
    member private this.radioButton1_CheckChanged() = //This method is called when the radiobutton (a button that when pressed makes every other radiobutton in its groupbox not pressed) is changed
        let x =
            if textBox1.Text = "" then "0" //This sees if x has no value and if it has none, then it sets x to 0
            else textBox1.Text
        let y =
            if textBox2.Text = "" then "0"
            else textBox2.Text
        let x_number = Convert.ToInt32(x) //This converts the string x to a integer then stores it in x_number
        let y_number = Convert.ToInt32(y)
        let random = x_number + y_number //This sets the integer variable random to the value of x_number plus y_number
        let random_string = Convert.ToString(random) //This converts the integer random to the string random_string
        do label3.Text <- random_string
    member private this.radioButton2_CheckChanged() = 
        let x =
            if textBox1.Text = "" then "0"
            else textBox1.Text
        let y =
            if textBox2.Text = "" then "0"
            else textBox2.Text
        let x_number = Convert.ToInt32(x)
        let y_number = Convert.ToInt32(y)
        let random = x_number - y_number
        let random_string = Convert.ToString(random)
        do label3.Text <- random_string
    member private this.radioButton3_CheckChanged() = 
        let x =
            if textBox1.Text = "" then "0"
            else textBox1.Text
        let y =
            if textBox2.Text = "" then "0"
            else textBox2.Text
        let x_number = Convert.ToInt32(x)
        let y_number = Convert.ToInt32(y)
        let random = x_number / y_number
        let random_string = Convert.ToString(random)
        do label3.Text <- random_string
    member private this.radioButton4_CheckChanged() = 
        let x =
            if textBox1.Text = "" then "0"
            else textBox1.Text
        let y =
            if textBox2.Text = "" then "0"
            else textBox2.Text
        let x_number = Convert.ToInt32(x)
        let y_number = Convert.ToInt32(y)
        let random = x_number * y_number
        let random_string = Convert.ToString(random)
        do label3.Text <- random_string
    member private this.radioButton5_CheckChanged() = 
        let x =
            if textBox1.Text = "" then "0"
            else textBox1.Text
        let y =
            if textBox2.Text = "" then "0"
            else textBox2.Text
        let x_number = Convert.ToInt32(x)
        let y_number = Convert.ToInt32(y)
        do pictureBox1.Image <-
            if x_number >= y_number then yes //This checks if the integer x_number is equal to the integer y_number
            else no //If they are not then the picture is set as an X
    member private this.radioButton6_CheckChanged() = 
        let x =
            if textBox1.Text = "" then "0"
            else textBox1.Text
        let y =
            if textBox2.Text = "" then "0"
            else textBox2.Text
        let x_number = Convert.ToInt32(x)
        let y_number = Convert.ToInt32(y)
        do pictureBox1.Image <-
            if x_number < y_number then yes
            else no
    member private this.radioButton7_CheckChanged() = 
        let x =
            if textBox1.Text = "" then "0"
            else textBox1.Text
        let y =
            if textBox2.Text = "" then "0"
            else textBox2.Text
        let x_number = Convert.ToInt32(x)
        let y_number = Convert.ToInt32(y)
        do pictureBox1.Image <-
            if x_number = y_number then yes
            else no
    member private this.radioButton8_CheckChanged() = 
        let x =
            if textBox1.Text = "" then "0"
            else textBox1.Text
        let y =
            if textBox2.Text = "" then "0"
            else textBox2.Text
        let x_number = Convert.ToInt32(x)
        let y_number = Convert.ToInt32(y)
        do pictureBox1.Image <-
            if x_number > y_number then yes
            else no
    member private this.radioButton9_CheckChanged() = 
        let x =
            if textBox1.Text = "" then "0"
            else textBox1.Text
        let y =
            if textBox2.Text = "" then "0"
            else textBox2.Text
        let x_number = Convert.ToInt32(x)
        let y_number = Convert.ToInt32(y)
        do pictureBox1.Image <-
            if x_number <= y_number then yes
            else no
    member private this.radioButton10_CheckChanged() = 
        let x =
            if textBox1.Text = "" then "0"
            else textBox1.Text
        let y =
            if textBox2.Text = "" then "0"
            else textBox2.Text
        let x_number = Convert.ToInt32(x)
        let y_number = Convert.ToInt32(y)
        do pictureBox1.Image <-
            if x_number <> y_number then yes
            else no
module Program =
    [<STAThread>]
    [<EntryPoint>] //This sets the entry point for the application
    do Application.EnableVisualStyles()
    do Application.SetCompatibleTextRenderingDefault(false)
    do Application.Run(new Form1())
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

var colors = ["red", "green", "blue", "orange", "purple", "yellow", "lime"];

function chooseColor() {
        var num = Math.floor(Math.random()*colors.length);
        return colors[num];
    }

function backgroundChange(elt) { 
          
           elt.style.backgroundColor = chooseColor();
    }


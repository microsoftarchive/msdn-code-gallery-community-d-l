//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

(function () {
    function id(elementId) {
        return document.getElementById(elementId); 
    }

    function dragStart(elt) { 
           elt.innherHTML = "dragged";
    }

    function checkShapeDrop(e) {
        document.getElementById("matchStatus").innerHTML = "&nbsp;";
    
        //  Remove the 'empty' and 'filled' part of the id's and compare the rest of the strings.  
        var target = this.id.replace("empty", "");
        var elt = e.dataTransfer.getData('text').replace("filled", "");
        if (target == elt) {  // if we have a match, replace empty shape with filled shape image
            this.children[0].src = "images/empty" + target + "2.png";

            //  Remove the original filled image to give illusion that the filled image is now inside the empty one
            document.getElementById(e.dataTransfer.getData('text')).style.display = "none";
        }
        else
        {
            document.getElementById("matchStatus").innerHTML = "<span style='color: red;'>Pieces don't match!</span>";
        }
    }

    // When dragging starts, set dataTransfer's data to the element's id.
    function startShapeDrag(e) {
        e.dataTransfer.setData('text', this.id);
    }
    
    function resetShapes() { 
        id('filledTriangle').style.display = "block";
        id('filledSquare').style.display = "block";
        id('filledCircle').style.display = "block";
        id('emptyTriangle').children[0].src = "images/emptyTriangle.png";
        id('emptySquare').children[0].src = "images/emptySquare.png";
        id('emptyCircle').children[0].src = "images/emptyCircle.png";
        document.getElementById("matchStatus").innerHTML = "&nbsp;";
    }

    function initialize() {
        //  Assign event listeners to the divs to handle dragging.
        document.getElementById('filledTriangle').addEventListener('dragstart', startShapeDrag, false);
        document.getElementById('filledCircle').addEventListener('dragstart', startShapeDrag, false);
        document.getElementById('filledSquare').addEventListener('dragstart', startShapeDrag, false);
        document.getElementById('emptyTriangle').addEventListener('drop', checkShapeDrop, false);
        document.getElementById('emptySquare').addEventListener('drop', checkShapeDrop, false);
        document.getElementById('emptyCircle').addEventListener('drop', checkShapeDrop, false);
        id('shapeButton').addEventListener('click', resetShapes, false);
    }

    document.addEventListener("DOMContentLoaded", initialize, false);
})();


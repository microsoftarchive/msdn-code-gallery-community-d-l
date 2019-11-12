<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebStorageWebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HTML 5 Web Storage</title>
    <script type="text/javascript">
        var isWebStorageSupported = false;

        window.onload = function ()
        {
            if (typeof (Storage) !== "undefined") {
                //your browser supports web storage.
                isWebStorageSupported = true;
            }
            else {
                //your browser doesn't support web storage.
                isWebStorageSupported = false;
            }
        }

        //check whether the browser supports web storage
        //and insert to local storage
        function insertToLocalStorage(id, value) {
            if (isWebStorageSupported) {
                if (id != "" && value != "") {
                    localStorage.setItem(id, value);
                    alert("Saved on Local Storage");
                }
            }
        }

        //check whether the browser supports web storage
        //and insert to session storage
        function insertToSessionStorage(id, value) {
            if (isWebStorageSupported) {
                if (id != "" && value != "") {
                    sessionStorage.setItem(id, value);
                    alert("Saved on Session Storage");
                }
            }
        }

        //check whether the browser supports web storage
        //show all items from local storage
        function getAllFromLocalStorage() {
            if (isWebStorageSupported) {
                for (var i = 0, len = localStorage.length; i < len; i++) {
                    var key = localStorage.key(i);
                    var value = localStorage.getItem(key);
                    alert(key + "=" + value);
                }
            }
        }

        //check whether the browser supports web storage
        //show all items from session storage
        function getAllFromSessionStorage() {
            if (isWebStorageSupported) {
                for (var i = 0, len = sessionStorage.length; i < len; i++) {
                    var key = sessionStorage.key(i);
                    var value = sessionStorage.getItem(key);
                    alert(key + "=" + value);
                }
            }
        }

        //clear all items from local and session storage
        function clearStorage()
        {
            if (isWebStorageSupported) {
                sessionStorage.clear();
                localStorage.clear();
                alert("Local Storage and Session Storage Cleared.")
            }
        }
    </script>

    <style type="text/css">
        .input {
            width:300px;
        }
        .container {
            width:800px;
            height:25px;
            display:inline-block;
            margin:2px;
            border:2px solid;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container" style="height:100px;">
                <p>Refresh the page and check the storages</p>
                <p>Close the window and open it again and check the storages.</p>
            </div>
            <div class="container">
                ID<input type="text" id="txtId" class="input" />
                Value<input type="text" id="txtValue"  class="input" />
            </div>
            
            <div class="container">
                <input type="button" value="Save - Session Storage" class="input" onclick="insertToSessionStorage(document.getElementById('txtId').value, document.getElementById('txtValue').value)" />
                <input type="button" value="Save - Local Storage"  class="input" onclick="insertToLocalStorage(document.getElementById('txtId').value, document.getElementById('txtValue').value)" />
            </div>
            
            <div class="container">
                <input type="button" value="Get - Session Storage" class="input" onclick="getAllFromSessionStorage()" />
                <input type="button" value="Get - Local Storage" class="input" onclick="getAllFromLocalStorage()" />
            </div>

            <div class="container">
                <input type="button" value="Clear Storage" class="input" onclick="clearStorage()" />
            </div>
        </div>
    </form>
</body>
</html>

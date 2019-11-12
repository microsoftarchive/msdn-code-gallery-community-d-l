<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IndexedDbWebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IndexedDB Sample</title>
    <script type="text/javascript">

        var indexedDB = window.indexedDB || window.webkitIndexedDB || window.mozIndexedDB || window.msIndexedDB;
        var db;

        if (!window.indexedDB) {
            alert("Your browser doesn't support IndexedDB");
        }

        window.onload = function () {
            initDb();
        }

        function initDb() {
            var request = indexedDB.open("ToDoDB", 1);
            request.onsuccess = function (event) {
                db = request.result;
                showAllItems();
            };
            request.onerror = function (event) {
                console.log("IndexedDB error: " + event.target.errorCode);
            };
            request.onupgradeneeded = function (event) {
                var objectStore = event.currentTarget.result.createObjectStore("todo", { keyPath: "id", autoIncrement: true });
                objectStore.createIndex("priority", "priority", { unique: false });
                objectStore.createIndex("tododesc", "tododesc", { unique: true });
            };
        }

        function addNewItem() {
            var priority = document.getElementById("txtPriority").value;
            var tododesc = document.getElementById("txtTodo").value;

            var transaction = db.transaction(["todo"], "readwrite");
            var objectStore = transaction.objectStore("todo");
            var request = objectStore.add({ priority: priority, tododesc: tododesc });
            request.onsuccess = function (event) {
                alert("added");
            };
        }

        function deleteItem(id) {
            var transaction = db.transaction(["todo"], "readwrite");
            var objectStore = transaction.objectStore("todo");
            var request = objectStore.delete(parseInt(id));
            request.onsuccess = function (event) {
                alert("deleted");
            };
            request.onerror = function (event) {
                alert("error deleting record");
            };
        }

        function showAllItems() {
            var transaction = db.transaction(["todo"], "readwrite");
            var objectStore = transaction.objectStore("todo");
            var request = objectStore.openCursor();

            request.onsuccess = function (event) {
                var cursor = event.target.result;
                if (cursor) {
                    alert("ID: " + cursor.key + " \nPriority: " + cursor.value.priority + " \nTo Do Desc: " + cursor.value.tododesc + " ");
                    cursor.continue();
                }
                else {
                    // no more records
                }
            };
        }

        function deleteDb() {
            var iDb = indexedDB.deleteDatabase("ToDoDB");
            iDb.onsuccess = function (event) {
                alert("database deleted");
            };
            iDb.onerror = function (event) {
                alert("error deleting database");
            };
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <label for="txtPriority" style="width:120px;position:absolute">
                Priority
            </label>
            <input type="text" id="txtPriority" name="txtPriority" style="width:305px; position:relative; top: 0px; left: 130px;"/>
            <br />
            <label for="txtTodo" style="width:120px;position:absolute">
                Todo
            </label>
            <input type="text" id="txtTodo" name="txtTodo" style="width:305px; position:relative; top: 0px; left: 130px;"/>
            <br />
            <input type="button" id="btnAdd" value="Add" style="width:126px" onclick="addNewItem()"/>
            <input type="button" id="btnShowAll" value="Show All" style="width:126px" onclick="showAllItems()"/>
            <br />
            <label for="txtId" style="width:120px;position:absolute">
                Id to delete
            </label>
            <input type="text" id="txtId" name="txtId" style="width:305px; position:relative; top: 0px; left: 130px;"/>
            <br />
            <input type="button" id="btnDelete" value="Delete" style="width:126px" onclick="deleteItem(document.getElementById('txtId').value)"/>
            <br />
            <input type="button" id="btnDeleteDb" value="Delete IndexedDB" style="width:126px" onclick="deleteDb()"/>
            <br />
        </div>
    </form>
</body>
</html>

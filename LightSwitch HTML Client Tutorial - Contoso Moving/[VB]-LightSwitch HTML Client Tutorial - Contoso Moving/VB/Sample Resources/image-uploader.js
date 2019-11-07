function createImageUploader(element, contentItem, previewStyle) {
    var relativePathFromClientRootToThisFolder = "Scripts/";
    //     (This path will be used for the fallback ASPX uploader.)


    var $element = $(element);


    // Try the local file-reading HTML-5 standard method first.
    //      If it fails, fall back on a method that will require an extra round-trip 
    //      to the server
    if (window.FileReader) {
        createHTML5Uploader();
    } else {
        createFallbackASPXUploader();
    }


    function createHTML5Uploader() {
        var $file_browse_button = $('<input name="file" type="file" style="margin-bottom: 10px;" />');
        $element.append($file_browse_button);

        var $preview = $('<div></div>');
        $element.append($preview);

        $file_browse_button.bind('change', function handleFileSelect(evt) {
            var files = evt.target.files;
            if (files.length == 1) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    previewImageAndSetContentItem(e.target.result, $preview, contentItem);
                };
                reader.readAsDataURL(files[0]);
            } else {
                // if no file was chosen (e.g., if file-choosing was cancelled),
                //     explicity ensure that the content is set back to null:
                previewImageAndSetContentItem(null, $preview, contentItem);
            }
        });
    }

    function createFallbackASPXUploader() {
        // Create a file submission form
        var $file_upload_form = $('<form method="post" ' +
                'action="' + relativePathFromClientRootToThisFolder + 'image-uploader-base64-encoder.aspx" ' +
                'enctype="multipart/form-data" target="uploadTargetIFrame" />');
        var $file_browse_button = $('<input name="file" type="file" style="margin-bottom: 10px;" />');
        $file_upload_form.append($file_browse_button);
        $element.append($file_upload_form);

        // Add an invisible IFrame that the contents of the file will be posted to:
        var $uploadTargetIFrame = $('<iframe name="uploadTargetIFrame" ' +
                'style="width: 0px; height: 0px; border: 0px solid #fff;"></iframe>');
        $element.append($uploadTargetIFrame);

        // Finally, add a preview div that will show a "processing" text during a round-trip to the server, 
        //      and will show the contents of the image once it is loaded.
        var $preview = $('<div></div>');
        $element.append($preview);


        // Having set up the content, wire it up:

        // On browsing to a file, automatically submit to inner IFrame
        $file_browse_button.change(function () {
            $file_upload_form.submit();
        });

        // On form submission, show a "processing" message:
        $file_upload_form.submit(function () {
            $preview.append($('<div>Processing...</div>'));
        });

        // Once the result frame is loaded (e.g., result came back), 
        //      preview the image and set the content item appropriately. 
        $uploadTargetIFrame.load(function () {
            var serverResponse = null;
            try {
                serverResponse = $uploadTargetIFrame.contents().find("body").html();
            } catch (e) {
                // request must have failed, keep server response empty. 
            }
            previewImageAndSetContentItem(serverResponse, $preview, contentItem);
        });
    }


    function previewImageAndSetContentItem(fullBinaryString, $preview, contentItem) {
        $preview.empty();

        if ((fullBinaryString == null) || (fullBinaryString.length == 0)) {
            contentItem.value = null;
        } else {
            $preview.append($('<img src="' + fullBinaryString + '" style="' + previewStyle + '" />'));
            // As far as storing the data in the database, beyond previewing it,
            //     remove the preamble returned by FileReader or the server 
            //     (always of the same form: "data:jpeg;base64," with variations only on the 
            //     type of data -- jpeg, png, etc).
            //     The first comma serves as the necessary marker where the binary data begins.
            contentItem.value = fullBinaryString.substring(fullBinaryString.indexOf(",") + 1);
        }
    }
}
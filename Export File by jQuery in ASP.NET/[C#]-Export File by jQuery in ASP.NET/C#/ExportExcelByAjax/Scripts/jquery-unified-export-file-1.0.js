/*!
 * jQuery JavaScript Unified Export File Library v1.0
 * http://dotnetmagazines.wordpress.com/
 *
 * Copyright 2013, Kevin Ly
 *
 * Date: Sat Aug 24 11:34:00 AM
 */
(function ($) {

	$.UnifiedExportFile = function (options) {

		/**********************************************************************************
			This is default option of plugin Download File. It consists of the following 
			members:
			1. action: action URL to download file.
			2. data: this is key-value pairs used for creating query strings.
			3. downloadType: this is download type used for checking which download type
				really necessary for user. It consists of 3 types: Normal (download without
				needing progress status), Progress (download with progress status) and
				ProgressBar (download with progress bar included calculations)
			4. ajaxLoadingSelector: to show the progress of downloading file. This is just
				working for 2 download types: Progress and ProgressBar
			5. maximumBar: this is the maximum of progress bar calculated by pixel
			6. progressBarSelector: this is progress bar selector
			7. calculatingSelector: this is status selector used for showing the calculation
				to the server
			8. onSuccessCallBack: this is a function will be called when downloading file
				successfully. This is just working on 2 download types: Progress and
				ProgressBar.
			9. onFailCallBack: this is a function will be called when downloading file
				unsuccessfully. This is just working on 2 download types: Progress and
				ProgressBar.
		***********************************************************************************/
		var defaultOptions = {
			action: '/',
			data: {},
			downloadType: 'Normal',
			ajaxLoadingSelector: '.ajax-loading',
			maximumBar: 400,
			progressBarSelector: '.progress',
			calculatingSelector: '.cal-progress',
			onSuccessCallBack: function () {
				$.UnifiedExportFile.onSuccessDefaultCallBack();
			},
			onFailCallBack: function () {
				$.UnifiedExportFile.onFailDefaultCallBack();
			}
		};

		var intervalProgressChanged;
		var intervalProgress;

		/********************************************
			Create new iframe and append it at the end
			of body document. It is used for downloading
			file from the server
		*********************************************/
		$.UnifiedExportFile.createIframeDownload = function (action) {
			var iframe = $('<iframe id="frmExportFile" target="_blank" name="frmExportFile" style="display:none" src="' + action + '"></iframe>');
			iframe.appendTo('body');
		};

		/********************************************
			This is a default onSuccess callback
		*********************************************/
		$.UnifiedExportFile.onSuccessDefaultCallBack = function () {
			var msg = 'Completed exporting file from the server back to the client';
			console.log(msg);
			alert(msg);
		};

		/********************************************
			This is a default onFail callback
		*********************************************/
		$.UnifiedExportFile.onFailDefaultCallBack = function () {
			var msg = 'There\'s error occured while exporting file from the server';
			console.log(msg);
			alert(msg);
		};

		/********************************************
			Convert user's options into obj
		*********************************************/
		var obj = $.extend(defaultOptions, options);

		/********************************************
			This is event progressChanged will be fired
			when the progress for downloading file
			changes
		*********************************************/
		$.UnifiedExportFile.progressChanged = function (numOfPixelPerSecond) {

			var $progress = $(obj.progressBarSelector);

			/********************************************
				Change the progress of downloading file
			*********************************************/
			var width = $progress.width() + numOfPixelPerSecond;

			/********************************************
				if the width of the progress is lower
				or equal than maximumBar, we will continue
				loading the progress.
			*********************************************/
			if (width <= obj.maximumBar) {
				$progress.width(width);
				$progress.html('Loading ' + Math.floor((width * 100) / obj.maximumBar) + '%');
			}
			else {
				/********************************************
					Clear the current interval if downloading
					file completely
				*********************************************/
				clearInterval(intervalProgressChanged);

				/********************************************
					Clear the current interval if downloading
					file completely
				*********************************************/
				$progress.width(obj.maximumBar);

				/********************************************
					Output the success message inside progress
					element
				*********************************************/
				$progress.html('Completed 100%');

				/********************************************
					Remove iframe download
				*********************************************/
				$('#frmExportFile').remove();

				obj.onSuccessCallBack();
			}
		}

		/********************************************
			Read cookie from document.cookie
		*********************************************/
		$.UnifiedExportFile.getCookie = function (cookieName) {
			var cookieValue = document.cookie;
			var c_start = cookieValue.indexOf(" " + cookieName + "=");
			if (c_start == -1) {
				c_start = cookieValue.indexOf(cookieName + "=");
			}
			if (c_start == -1) {
				cookieValue = null;
			}
			else {
				c_start = cookieValue.indexOf("=", c_start) + 1;
				var c_end = cookieValue.indexOf(";", c_start);
				if (c_end == -1) {
					c_end = cookieValue.length;
				}
				cookieValue = unescape(cookieValue.substring(c_start, c_end));
			}
			return cookieValue;
		}

		/********************************************
			Remove cookie in document.cookie
		*********************************************/
		$.UnifiedExportFile.removeCookie = function (cookieName) {
			var cookies = document.cookie.split(";");

			for (var i = 0; i < cookies.length; i++) {
				var cookie = cookies[i];
				var eqPos = cookie.indexOf("=");
				var name = eqPos > -1 ? cookie.substr(0, eqPos) : cookie;
				if (name == cookieName) {
					document.cookie = name + "=;expires=Thu, 01 Jan 1970 00:00:00 GMT;path=/";
				}
			}
		}

		/********************************************
			This is checkDownloadFileCompletely will 
			be fired when the file has been downloaded
			completely
		*********************************************/
		$.UnifiedExportFile.checkDownloadFileCompletely = function () {

			/********************************************
				Read cookie Downloaded=True
			*********************************************/
			var downloaded = $.UnifiedExportFile.getCookie('Downloaded');

			/********************************************
				If true, downloaded completely
			*********************************************/
			if (downloaded == "True") {

				/********************************************
					Hide ajax loading element
				*********************************************/
				$(obj.ajaxLoadingSelector).hide();

				/********************************************
					Remove cookie "Downloaded=True"
				*********************************************/
				$.UnifiedExportFile.removeCookie('Downloaded');

				/********************************************
					Clear the current interval if downloading
					file completely
				*********************************************/
				clearInterval(intervalProgress);

				$('#frmExportFile').remove();

				obj.onSuccessCallBack();
			}
		};

		/********************************************
			This is a flag to check errors
		*********************************************/
		var hasErrors = false;

		/********************************************
			Check action is empty or not. If empty, we
			will write error log to developers tool
		*********************************************/
		if (obj.action.length <= 0) {
			console.log('Action URL must be a valid URL and not empty');
			hasErrors = true;
		}

		/********************************************
			Check number of elements of ajax loading 
			If being lower or equal to zero, we will write
			warning log to developer tool
		*********************************************/
		if (obj.ajaxLoadingSelector.length <= 0) {
			console.log('Ajax Loading Selector doesn\'t exist');
		}

		/********************************************
			Only execute plugin if there is no any errors
		*********************************************/
		if (!hasErrors) {
			var queryStrings = "?";
			var nameValuePair = '';
			var action = obj.action;

			$('#frmExportFile').remove();
			$.UnifiedExportFile.removeCookie('Downloaded');

			/********************************************
				Create query strings based on data to transfer
				to the server
			*********************************************/
			for (var propertyName in obj.data) {
				nameValuePair = propertyName + "=" + obj.data[propertyName];
				queryStrings = queryStrings + (queryStrings.length > 1 ? ("&" + nameValuePair) : nameValuePair);
			}

			/********************************************
				If the length of query strings is greater
				than 1, we will add querystring at the end of
				action URL
			*********************************************/
			if (queryStrings.length > 1) {
				action = action + queryStrings;
			}

			switch (obj.downloadType) {
				case 'Normal':
					$.UnifiedExportFile.createIframeDownload(action);
					break;

				case 'Progress':
					/********************************************
						Show the downloading progress
					*********************************************/
					$(obj.ajaxLoadingSelector).show();
					
					$.UnifiedExportFile.createIframeDownload(action);

					/********************************************
						Set up interval each times will fire the
						function checkDownloadFileCompletely
						to check the downloaded file completely
					*********************************************/
					intervalProgress = setInterval("$.UnifiedExportFile.checkDownloadFileCompletely()", 1000);
					break;

				case 'ProgressBar':
					/********************************************
						Show the calculation progress
					*********************************************/
					$(obj.ajaxLoadingSelector).show();

					/********************************************
						Check if there isn't the existed calculating
						selector, we will create default
						calculating element defaultly
					*********************************************/
					if ($(obj.calculatingSelector).length <= 0) {
						$('<div class="cal-progress">Calculating and checking...</div>').insertAfter($(obj.ajaxLoadingSelector));
					}

					/********************************************
						Get current time to calculate the elapsed
						time
					*********************************************/
					var currentTime = new Date().getTime();

					/********************************************
						Call ajax to calculate the elapsed
						time
					*********************************************/
					$.ajax({
						url: action,
						success: function (data) {

							/********************************************
								Check if there isn't the existed progress
								bar selector, we will create default
								progress bar defaultly
							*********************************************/
							if ($(obj.progressBarSelector).length <= 0) {
								$('<div style="width: ' + obj.maximumBar + 'px; border: 2px solid #bc3d11; height: 20px;"><div class="progress" style="color: white; background-color:#2383c4; width: 0px">Loading</div></div>')
									.insertAfter($(obj.ajaxLoadingSelector));
							}

							/********************************************
								Calculate the elapsed time based upon current
								Time and previous Time
							*********************************************/
							var elapsedTime = new Date().getTime() - currentTime;

							/********************************************
								Hide the calculation progress
							*********************************************/
							$('.cal-progress, ' + obj.ajaxLoadingSelector).hide();

							/********************************************
								Calculate number of pixels per second
							*********************************************/
							var numOfPixelPerSecond = obj.maximumBar / (elapsedTime / 1000);

							$.UnifiedExportFile.createIframeDownload(action);

							/********************************************
								Set up interval each times will fire the
								function progressChanged to update status
							*********************************************/
							intervalProgressChanged = setInterval("$.UnifiedExportFile.progressChanged(" + numOfPixelPerSecond + ")", 1000);
						},
						error: obj.onFailCallBack,
						complete: function () {
							/********************************************
								Hide the progress
							*********************************************/
							$('.cal-progress, ' + obj.ajaxLoadingSelector).hide();
						}
					});
				break;

				default:
					$.UnifiedExportFile.createIframeDownload(action);
				break;
			}
		}

		return false;
	}
})(jQuery);
var Effects = (function() {

	var canvas = canvas || {} ;
	var ctx = ctx || {} ;
	var buttons = buttons || [] ;
	var buffer = buffer || [] ;
	var index = 1 | 0 ;
	
	function restore(imageData) {
		for(var i = 0; i < imageData.data.length; i += 4) {
			imageData.data[i] = buffer.data[i];
			imageData.data[i + 1] = buffer.data[i + 1];
			imageData.data[i + 2] = buffer.data[i + 2];
		}
		return imageData ;
	}
	
	var performEffect = [ 
		restore, Filters.grayscale, Filters.duotone, Filters.noise, Filters.invert, Filters.pixelate, Filters.brighten,
		Filters.sepiaTone, Filters.contrast, Filters.threshold, Filters.gamma, Filters.pencilSketch, Filters.posterize,
		Filters.scatter, Filters.solarize, Filters.ASCII, Filters.blur, Filters.sharpen, Filters.edgeDetect, Filters.emboss, 
		Filters.lighten, Filters.darken, Filters.sobel, Filters.gaussianBlur ];
	
	function applyEffect(index) {
		ctx.putImageData(buffer, 0, 0);
		var input = ctx.getImageData(0, 0, canvas.width, canvas.height);
		var output = performEffect[index](input);
		ctx.putImageData(output, 0, 0);
	}
	
	var initialize = function() {
		canvas = document.getElementById('image-effects');
		ctx = canvas.getContext('2d');
		var image = new Image();
		image.onload = function() {
			ctx.drawImage(image, 0, 0);
			buffer = ctx.getImageData(0, 0, canvas.width, canvas.height);
		};
		image.src = 'image' + index + '.png';
		buttons = document.getElementsByClassName('effect');
		for(var i=0; i<buttons.length; ++i) {
			(function (index) {
				buttons[index].addEventListener('click', function () {
					applyEffect(index);
				}, false);
			}(i));
		}
		document.getElementById('nav').addEventListener('click',
			function () { 
				index = (index % 3) + 1 ;
				image.src = 'image' + index + '.png'; 
			}, false);
	};
	
	return {
		init : initialize
	};
	
}());
		
self.onmessage = function (e) {
    var canvasData = e.data.data;
    var pix = canvasData.data;

    var len = pix.length;
    var enableHardEdge = e.data.enableHardEdge;
    var intensity = e.data.intensity;
    var temperaturemap = e.data.temperaturemap;

    if (enableHardEdge) {
        var alphaOverride = 256 * intensity;
        var alpha;

        for (var p = 0; p < len; p += 4) {
            alpha = pix[p + 3] * 4; // get the alpha of this pixel
            if (alpha != 0) { // If there is any data to plot
                pix[p] = temperaturemap[alpha]; // set the red value of the gradient that corresponds to this alpha
                pix[p + 1] = temperaturemap[alpha + 1]; //set the green value based on alpha
                pix[p + 2] = temperaturemap[alpha + 2]; //set the blue value based on alpha
                pix[p + 3] = alphaOverride;
            }
        }
    } else {
        for (var p = 0; p < len; p += 4) {
            alpha = pix[p + 3] * 4; // get the alpha of this pixel
            if (alpha != 0) { // If there is any data to plot
                pix[p] = temperaturemap[alpha]; // set the red value of the gradient that corresponds to this alpha
                pix[p + 1] = temperaturemap[alpha + 1]; //set the green value based on alpha
                pix[p + 2] = temperaturemap[alpha + 2]; //set the blue value based on alpha
            }
        }
    }

    self.postMessage({ result: canvasData, id: e.data.id });
};
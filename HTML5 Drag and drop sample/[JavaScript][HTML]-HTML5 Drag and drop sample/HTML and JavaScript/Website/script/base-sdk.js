//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved.

(function () {

    function initialize() {

        // Add sdk sample header
        var header = document.getElementById("header");
        if (Boolean(header)) {
            // Link to IE Dev Center home
            var logoLink = document.createElement("a");
            var logo = document.createElement("img");
            logo.src = "images/ie-sdk.png";
            logo.alt = "Internet Explorer";
            logoLink.href = "http://msdn.microsoft.com/ie";
            logoLink.appendChild(logo);
            header.appendChild(logoLink);

            // Link to this sample's specific info page in code gallery
            var titleLink = document.createElement("a");
            var title = document.createElement("span");
            title.innerHTML = "Internet Explorer Samples";
            titleLink.href = "http://code.msdn.microsoft.com/ie/Drag-and-drop-e2701a72";
            titleLink.appendChild(title);
            header.appendChild(titleLink);
        }

        // Add sdk sample footer
        var footer = document.getElementById("footer");
        if (Boolean(footer)) {
            var footerLogo = document.createElement("img");
            var footerText = document.createElement("div");
            var links = document.createElement("div");
            var company = document.createElement("div");
            var companyText = document.createElement("span");
            var terms = document.createElement("a");
            var pipe = document.createElement("span");
            var trademarks = document.createElement("a");
            var privacy = document.createElement("a");

            footerLogo.src = "images/microsoft-sdk.png";
            footerLogo.alt = "Microsoft";
            company.className = "company";
            companyText.innerHTML = "&copy; 2012 Microsoft Corporation. All rights reserved.";
            terms.innerHTML = "Terms of use";
            terms.href = "http://www.microsoft.com/About/Legal/EN/US/IntellectualProperty/Copyright/default.aspx";
            trademarks.innerHTML = "Trademarks";
            trademarks.href = "http://www.microsoft.com/About/Legal/EN/US/IntellectualProperty/Trademarks/EN-US.aspx";
            privacy.innerHTML = "Privacy Statement";
            privacy.href = "http://privacy.microsoft.com";
            links.className = "links";
            pipe.className = "pipe";

            links.appendChild(terms);
            links.appendChild(pipe);
            links.appendChild(trademarks);
            links.appendChild(pipe.cloneNode(true));
            links.appendChild(privacy);

            company.appendChild(companyText);
            footerText.appendChild(company);
            footerText.appendChild(links);

            footer.appendChild(footerLogo);
            footer.appendChild(footerText);
        }
    }

    if(document.addEventListener) {
        document.addEventListener("DOMContentLoaded", initialize, false);
    }else{
        window.attachEvent("onload",initialize);
    }
})();
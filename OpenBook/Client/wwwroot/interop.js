window.downloadFile = function (fileName, filePath) {
    var anchor = document.createElement('a');
    anchor.href = window.URL.createObjectURL(new Blob([filePath], { type: 'application/octet-stream' }));
    anchor.download = fileName;
    document.body.appendChild(anchor);
    anchor.click();
    document.body.removeChild(anchor);
};
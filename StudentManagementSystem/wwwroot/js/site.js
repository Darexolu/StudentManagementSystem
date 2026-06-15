function scrollToRow(id) {
	const element = document.getElementById(id);
	if (element) {
		element.scrollIntoView({ behavior: "smooth", block: "center" });
	}
}

window.downloadFile = (fileName, byteArray) => {
	console.log("downloadfile")
	const blob = new Blob([new Uint8Array(byteArray)], {
		type: "application/pdf"
	});

	const link = document.createElement('a');

	link.href = window.URL.createObjectURL(blob);
	link.download = fileName;

	document.body.appendChild(link);
	link.click();

	document.body.removeChild(link);
};
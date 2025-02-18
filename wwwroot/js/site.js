//updates the modal image when an image is clicked.
function setModalImage(imgElement) {
    let modalImage = document.getElementById("modalImage");

    console.log("Clicked image source:", imgElement.src); // Debugging
    modalImage.src = imgElement.src;
    modalImage.alt = imgElement.alt;
    
    console.log("Modal image source set to:", modalImage.src); // Debugging
}
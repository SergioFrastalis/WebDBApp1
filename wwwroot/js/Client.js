function confirmDelete(clientId) {
    if (confirm("Are you sure you want to delete this client?")) {
        window.location.href = "/Clients/" + clientId + "/Delete";
    }
}

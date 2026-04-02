
window.confirmAction = function confirmAction(title, text, onConfirm) {
    Swal.fire({
        title: title,
        text: text,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#6c757d',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.isConfirmed) {
            onConfirm();
        }
    });
}

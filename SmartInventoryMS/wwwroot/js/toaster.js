/**
 * Show a dynamic toast notification based on type
 * @param {string} message - Message to display
 * @param {string} type - success, danger, warning, info
 * @param {number} delay - How long to show in milliseconds (default 3000)
 */
function showToast(message, type = "success", delay = 3000) {
    const toastId = "toast" + Date.now();

    // Map type to Bootstrap colors
    const typeColors = {
        success: "rgba(40, 167, 69, 0.85)",  // green, 85% opacity
        danger: "rgba(220, 53, 69, 0.85)",   // red
        warning: "rgba(255, 193, 7, 0.85)",  // yellow
        info: "rgba(13, 110, 253, 0.85)"     // blue
    };

    const bgColor = typeColors[type] || "#28a745"; // default green
    const textColor = (type === "warning") ? "#000000" : "#ffffff"; // black for warning, white otherwise

    const toastHtml = `
        <div id="${toastId}" class="toast align-items-center border-0 mb-2" role="alert" aria-live="assertive" aria-atomic="true"
            style="background-color: ${bgColor}; color: ${textColor};">
            <div class="d-flex">
                <div class="toast-body">
                    ${message}
                </div>
                <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
            </div>
        </div>
    `;

    const container = document.getElementById("toastContainer");
    container.insertAdjacentHTML("beforeend", toastHtml);

    const toastEl = document.getElementById(toastId);
    const bsToast = new bootstrap.Toast(toastEl, { delay: delay });
    bsToast.show();

    toastEl.addEventListener('hidden.bs.toast', () => toastEl.remove());
}



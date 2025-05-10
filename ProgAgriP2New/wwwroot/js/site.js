// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/**
 * Password visibility toggle functionality
 * This function initializes password toggle buttons throughout the site
 */
document.addEventListener('DOMContentLoaded', function () {
    // Get all password toggle buttons
    const toggleButtons = document.querySelectorAll('.toggle-password');

    // Add click event to each toggle button
    toggleButtons.forEach(button => {
        button.addEventListener('click', function () {
            // Find the closest password input field
            const passwordInput = this.closest('.input-group').querySelector('input');

            // Toggle the password field type
            const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
            passwordInput.setAttribute('type', type);

            // Toggle the button text and icon
            if (type === 'text') {
                this.innerHTML = '<i class="bi bi-eye-slash"></i> Hide';
            } else {
                this.innerHTML = '<i class="bi bi-eye"></i> Show';
            }
        });
    });
});

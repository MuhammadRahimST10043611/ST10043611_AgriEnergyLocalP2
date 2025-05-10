// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Password visibility toggle functionality
document.addEventListener('DOMContentLoaded', function () {
    // Get all password toggle buttons (both the one in Login and the ones using toggle-password class)
    const toggleButtons = document.querySelectorAll('#togglePassword, .toggle-password');

    toggleButtons.forEach(button => {
        button.addEventListener('click', function () {
            // Find the password input
            let passwordInput;

            // Handle different structures (Login page vs other forms)
            if (this.id === 'togglePassword') {
                // For Login page (specific ID)
                passwordInput = document.getElementById('Password');
            } else {
                // For other pages (using closest to find the input within the same input-group)
                passwordInput = this.closest('.input-group').querySelector('input[type="password"], input[type="text"]');
            }

            // Toggle the type
            if (passwordInput) {
                const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
                passwordInput.setAttribute('type', type);

                // Toggle the button text and icon
                if (type === 'text') {
                    this.innerHTML = '<i class="bi bi-eye-slash"></i> Hide';
                } else {
                    this.innerHTML = '<i class="bi bi-eye"></i> Show';
                }
            }
        });
    });
});

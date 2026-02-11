// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
<script>
    // Dark Mode 
    document.body.classList.add('dark-mode');
    document.querySelector('.navbar').classList.add('dark-mode');
    document.querySelectorAll('.nav-link').forEach(el => el.classList.add('dark-mode'));
    document.querySelector('footer').classList.add('dark-mode');

    
    const btn = document.getElementById('darkModeBtn');
    btn.addEventListener('click', () => {
        document.body.classList.toggle('dark-mode');
    document.querySelector('.navbar').classList.toggle('dark-mode');
        document.querySelectorAll('.nav-link').forEach(el => el.classList.toggle('dark-mode'));
    document.querySelector('footer').classList.toggle('dark-mode');
    });
</script>


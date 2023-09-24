const openSidebarButton = document.getElementById('openSidebar');
const sidebarContainer = document.getElementById('sidebarContainer');

openSidebarButton.addEventListener('click', () => {
    sidebarContainer.style.left = '0';
});

// Close sidebar when clicking outside
window.addEventListener('click', (event) => {
    if (event.target !== sidebarContainer && event.target !== openSidebarButton) {
        sidebarContainer.style.left = '-300px';
    }
});

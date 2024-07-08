window.initializeSwipe = (card, dotNetHelper) => {
    let startX, startY, isDragging = false;

    const disableScroll = () => {
        document.body.style.overflow = 'hidden'; // Disable scrolling
    };

    const enableScroll = () => {
        document.body.style.overflow = ''; // Enable scrolling
    };

    const onMove = (event) => {
        if (!isDragging) return;
        let currentX = event.type === 'mousemove' ? event.clientX : event.touches[0].clientX;
        let currentY = event.type === 'mousemove' ? event.clientY : event.touches[0].clientY;

        let deltaX = currentX - startX;
        let deltaY = currentY - startY;
        let rotation = deltaX * 20 / window.innerWidth; // Rotation degree depending on swipe length

        card.style.transform = `translate(${deltaX}px, ${deltaY}px) rotate(${rotation}deg)`;
    };

    const onEnd = (event) => {
        isDragging = false;
        enableScroll(); // Re-enable scrolling when the swipe ends
        document.removeEventListener('mousemove', onMove);
        document.removeEventListener('mouseup', onEnd);
        document.removeEventListener('touchmove', onMove);
        document.removeEventListener('touchend', onEnd);

        const translateX = parseInt(card.style.transform.split('(')[1]);
        const threshold = window.innerWidth * 0.3; // Threshold to consider the swipe as valid

        if (Math.abs(translateX) > threshold) {
            let direction = translateX > 0 ? 'right' : 'left';
            card.style.transition = 'transform 0.5s ease-in';
            card.style.transform = `translateX(${direction === 'right' ? 1500 : -1500}px) rotate(${direction === 'right' ? 30 : -30}deg)`;
            setTimeout(() => {
                dotNetHelper.invokeMethodAsync('OnSwipeDetected', direction);
            }, 500);
        } else {
            // Spring back to the original position
            card.style.transition = 'transform 0.5s ease-out';
            card.style.transform = 'translate(0px, 0px) rotate(0deg)';
        }
    };

    const onStart = (event) => {
        isDragging = true;
        disableScroll(); // Disable scrolling when swipe starts
        startX = event.type === 'mousedown' ? event.clientX : event.touches[0].clientX;
        startY = event.type === 'mousedown' ? event.clientY : event.touches[0].clientY;
        card.style.transition = 'none'; // Remove transition to follow the cursor in real time

        document.addEventListener('mousemove', onMove);
        document.addEventListener('mouseup', onEnd);
        document.addEventListener('touchmove', onMove);
        document.addEventListener('touchend', onEnd);
    };

    card.addEventListener('mousedown', onStart);
    card.addEventListener('touchstart', onStart);
};

window.removeCard = (card) => {
    if (card && card.parentNode) {
        card.parentNode.removeChild(card);
    }
};

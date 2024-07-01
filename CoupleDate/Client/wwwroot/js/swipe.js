window.initializeSwipe = (card, dotNetHelper) => {
    if (card.getAttribute('data-init') === 'true') {
        console.log("Swipe already initialized for", card.id);
        return; // Exit if the element is already initialized
    }

    console.log("initializeSwipe called for", card.id);
    card.setAttribute('data-init', 'true'); // Mark as initialized

    let startX;
    let currentX;
    let offsetX = 0;
    const threshold = 150;
    const maxTranslateX = 100; // Maximum translation distance in pixels
    const maxRotate = 15; // Maximum rotation in degrees
    let swipeProcessed = false; // Flag to ensure single processing

    const onMove = (event) => {
        if (swipeProcessed) return; // Prevent further processing if already processed

        if (event.type === 'mousemove') {
            currentX = event.clientX;
        } else if (event.type === 'touchmove') {
            currentX = event.touches[0].clientX;
        }

        offsetX = currentX - startX;

        if (card) {
            // Limit translation distance
            let translateX = Math.max(-maxTranslateX, Math.min(offsetX, maxTranslateX));
            // Calculate rotation based on limited translation distance
            let rotate = (translateX / maxTranslateX) * maxRotate;
            card.style.transform = `translateX(${translateX}px) rotate(${rotate}deg)`;
        }
    };

    const onEnd = async () => {
        if (swipeProcessed) return; // Prevent further processing if already processed

        document.removeEventListener('mousemove', onMove);
        document.removeEventListener('mouseup', onEnd);
        document.removeEventListener('touchmove', onMove);
        document.removeEventListener('touchend', onEnd);

        const translateX = offsetX;
        const direction = translateX > 0 ? 'right' : 'left';

        if (Math.abs(translateX) > threshold) {
            // Apply the final swipe action
            if (card) {
                card.style.transition = 'transform 0.5s ease';
                card.style.transform = `translateX(${direction === 'right' ? '100%' : '-100%'}) rotate(${(direction === 'right' ? maxRotate : -maxRotate)}deg)`;
                await dotNetHelper.invokeMethodAsync('OnSwipeDetected', direction);
                swipeProcessed = true; // Mark swipe as processed
            }
        } else {
            // Reset the card position
            if (card) {
                card.style.transition = 'transform 0.5s ease';
                card.style.transform = 'translateX(0px) rotate(0deg)';
            }
        }
    };

    const onStart = (event) => {
        swipeProcessed = false; // Reset the flag on new swipe start
        if (event.type === 'mousedown') {
            startX = event.clientX;
        } else if (event.type === 'touchstart') {
            startX = event.touches[0].clientX;
        }
        currentX = startX;
        if (card) {
            card.style.transition = 'none';
        }
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

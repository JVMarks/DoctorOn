const menuItems = document.querySelectorAll('#menu .link');
function getScrollTopByHref(element) {
	const id = element.getAttribute('href');
	return document.querySelector(id).offsetTop;
}

function scrollToIdOnClick(event) {
	event.preventDefault();
	const to = getScrollTopByHref(event.currentTarget) - 80;/*80*/
	scrollToPosition(to);
}

menuItems.forEach(item => {
	item.addEventListener('click', scrollToIdOnClick);
});

function scrollToPosition(to) {
	window.scroll({
		top: to,
		behavior: "smooth",
	})
	smoothScrollTo(0, to);
}

function smoothScrollTo(endX, endY, duration) {
	const startX = window.scrollX || window.pageXOffset;
	const startY = window.scrollY || window.pageYOffset;
	const distanceX = endX - startX;
	const distanceY = endY - startY;
	const startTime = new Date().getTime();

	duration = typeof duration !== 'undefined' ? duration : 400;

	const easeInOutQuart = (time, from, distance, duration) => {
		if ((time /= duration / 2) < 1) return distance / 2 * time * time * time * time + from;
		return -distance / 2 * ((time -= 2) * time * time * time - 2) + from;
	};

	const timer = setInterval(() => {
		const time = new Date().getTime() - startTime;
		const newX = easeInOutQuart(time, startX, distanceX, duration);
		const newY = easeInOutQuart(time, startY, distanceY, duration);
		if (time >= duration) {
			clearInterval(timer);
		}
		window.scroll(newX, newY);
	}, 1000 / 60);
};

//UP 
$(function () {
const introHeight = document.querySelector('.intro').offsetHeight;
const topButton = document.getElementById('top-button');
const $topButton = $('#top-button');

window.addEventListener('scroll', function () {
	if (window.scrollY > introHeight)
	{
		$topButton.fadeIn()
	} else
	{
		$topButton.fadeOut()
	}
}, !1);

topButton.addEventListener('click', function () { $('html, body').animate({ scrollTop: 0 }, 500) });

const hand = document.querySelector('.emoji.wave-hand');

function waveOnLoad() {
	hand.classList.add('wave');
	setTimeout(function () { hand.classList.remove('wave') }, 2000)
	} setTimeout(function () { waveOnLoad() }, 1000);

hand.addEventListener('mouseover', function () { hand.classList.add('wave') });
hand.addEventListener('mouseout', function () { hand.classList.remove('wave') });
window.sr = ScrollReveal({ reset: !1, duration: 600, easing: 'cubic-bezier(.694,0,.335,1)', scale: 1, viewFactor: 0.3, });

sr.reveal('.background');
sr.reveal('.skills');
sr.reveal('.experience', { viewFactor: 0.2 });
sr.reveal('.featured-projects', { viewFactor: 0.1 });
sr.reveal('.other-projects', { viewFactor: 0.05 })
});

if (document.addEventListener)
{
	document.addEventListener('contextmenu', function (e) { e.preventDefault() }, !1)
}
else
{
	document.attachEvent('oncontextmenu', function () { window.event.returnValue = !1 })
}

//CARD-PRODUTOS
window.addEventListener('load', function () {
	setTimeout(lazyLoad, 1000);

});

function lazyLoad() {
	var card_images = document.querySelectorAll('.card-image');
	card_images.forEach(function (card_image) {
		var image_url = card_image.getAttribute('data-image-full');
		var content_image = card_image.querySelector('img');

		content_image.src = image_url;
		content_image.addEventListener('load', function () {
			card_image.style.backgroundImage = 'url(' + image_url + ')';
			card_image.className = card_image.className + ' is-loaded';
		});

	});

}
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm14.aspx.cs" Inherits="Gabay_Final_V2.Prototype.WebForm14" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        /* Click the image one by one to see the different layout */

        /* Owl Carousel */

        .owl-prev {
            background: url('https://res.cloudinary.com/milairagny/image/upload/v1487938188/left-arrow_rlxamy.png') left center no-repeat;
            height: 54px;
            position: absolute;
            top: 50%;
            width: 27px;
            z-index: 1000;
            left: 2%;
            cursor: pointer;
            color: transparent;
            margin-top: -27px;
        }

        .owl-next {
            background: url('https://res.cloudinary.com/milairagny/image/upload/v1487938220/right-arrow_zwe9sf.png') right center no-repeat;
            height: 54px;
            position: absolute;
            top: 50%;
            width: 27px;
            z-index: 1000;
            right: 2%;
            cursor: pointer;
            color: transparent;
            margin-top: -27px;
        }

            .owl-prev:hover,
            .owl-next:hover {
                opacity: 0.5;
            }


        /* Owl Carousel */


        /* Popup Text */

        .white-popup-block {
            background: #FFF;
            padding: 20px 30px;
            text-align: left;
            max-width: 650px;
            margin: 40px auto;
            position: relative;
        }

        .popuptext {
            display: table;
        }

            .popuptext p {
                margin-bottom: 10px;
            }

            .popuptext span {
                font-weight: bold;
                float: right;
            }
        /* Popup Text */

        /* Icon CSS */
        .item {
            position: relative;
        }

            .item i {
                display: none;
                font-size: 4rem;
                color: #FFF;
                opacity: 1;
                position: absolute;
                top: 50%;
                left: 50%;
                transform: translate(-50%, -50%);
                -webkit-transform: translate(-50%, -50%);
            }

            .item a {
                display: block;
                width: 100%;
            }

                .item a:hover:before {
                    content: "";
                    background: rgba(0, 0, 0, 0.5);
                    position: absolute;
                    height: 100%;
                    width: 100%;
                    z-index: 1;
                }

                .item a:hover i {
                    display: block;
                    z-index: 2;
                }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="owl-carousel">
            <div class="item">
                <a class="popup-youtube" href="https://www.youtube.com/watch?v=5SJml0MBhW4?autoplay=1&rel=0&controls=0&showinfo=0&wmode=transparent">
                    <img src="https://res.cloudinary.com/milairagny/image/upload/v1487938016/pexels-photo-4_tfmpvk.jpg"/><i class="fa fa-play" aria-hidden="true"></i></a>
            </div>
            <div class="item">
                <a class="popup-youtube" href="https://www.youtube.com/watch?v=5SJml0MBhW4?autoplay=1&rel=0&controls=0&showinfo=0&wmode=transparent">
                    <img src="https://res.cloudinary.com/milairagny/image/upload/v1487938017/pexels-photo-3_ppz2bb.jpg"/><i class="fa fa-play" aria-hidden="true"></i></a>
            </div>
            <div class="item">
                <a class="popup-text" href="#1">
                    <img src="https://res.cloudinary.com/milairagny/image/upload/v1487938016/pexels-photo-2_hstxhf.jpg"/><i class="fa fa-newspaper-o" aria-hidden="true"></i>
                </a>
                <div id="1" class="mfp-hide white-popup-block popup-text">
                    <p>Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu.</p>
                    <span>- Opal Ingram</span>
                </div>
            </div>
            <div class="item">
                <a class="popup-youtube" href="https://www.youtube.com/watch?v=5SJml0MBhW4?autoplay=1&rel=0&controls=0&showinfo=0&wmode=transparent">
                    <img src="https://res.cloudinary.com/milairagny/image/upload/v1487938123/pexels-photo-5_x69tiz.jpg"/><i class="fa fa-play" aria-hidden="true"></i>
                </a>
            </div>
            <div class="item">
                <a class="popup-text" href="#2">
                    <img src="https://res.cloudinary.com/milairagny/image/upload/v1487937862/pexels-photo-91227_lpsizl.jpg"/><i class="fa fa-newspaper-o" aria-hidden="true"></i>
                </a>
                <div id="2" class="mfp-hide white-popup-block popup-text">
                    <p>Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu.</p>
                    <span>- Rick Baleno</span>
                </div>
            </div>
        </div>
    </form>
    <script>
        $('.owl-carousel').owlCarousel({
            autoplay: true,
            autoplayTimeout: 5000,
            autoplayHoverPause: true,
            loop: true,
            margin: 50,
            responsiveClass: true,
            nav: true,
            loop: true,
            stagePadding: 100,
            responsive: {
                0: {
                    items: 1
                },
                568: {
                    items: 2
                },
                600: {
                    items: 3
                },
                1000: {
                    items: 3
                }
            }
        })
        $(document).ready(function () {
            $('.popup-youtube').magnificPopup({
                disableOn: 320,
                type: 'iframe',
                mainClass: 'mfp-fade',
                removalDelay: 160,
                preloader: false,
                fixedContentPos: true
            });
        });
        $('.item').magnificPopup({
            delegate: 'a',
        });
    </script>
</body>
</html>

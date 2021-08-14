$(document).ready(function(){

    $('.fa-bars').click(function(){
        $(this).toggleClass('fa-times');
        $('.nav').toggleClass('nav-toggle');
    });
    
    $(window).on('load scroll',function(){
        $('.fa-bars').removeClass('fa-times');
        $('.nav').removeClass('nav-toggle');

        if($(window).scrollTop() > 10){
            $('header').addClass('header-active');
          }else{
            $('header').removeClass('header-active');
          }
      
        });
      
        $('.facility').magnificPopup({
          delegate:'a',
          type:'image',
          gallery:{
            enabled:true
          }
        });
      
      });

// My Header Template
class MyHeader extends HTMLElement{
    connectedCallback(){
        this.innerHTML = `
            <!-- header and nav bar section starts -->
            <header>
                <div class="container">
                    <a href="#" class="logo">
                        <i class="fas fa-book-open"></i>
                        <span> S</span>tudy<span>B</span>uddy
                        <i class="fas fa-graduation-cap"></i>
                    </a>
                    
                    <nav class="nav">
                        <ul>
                            <li><a href="/html/index.html">Home</a></li>
                            <li><a href="login">Login</a></li>
                            <li><a href="signup">Sign Up</a></li>
                            <li><a href="/html/about.html">About us</a></li>
                        </ul>
                    </nav>
                    
                    <!-- right bar for responsive view -->
                    <div class="fas fa-bars"> </div>

                </div>
            </header>
            <!-- header and nav bar section ends -->`
    }
}

customElements.define('my-header', MyHeader)


// My MyFooter Template
class MyFooter extends HTMLElement{
    connectedCallback(){
        this.innerHTML = ``
    }
}

customElements.define('my-footer', MyFooter)
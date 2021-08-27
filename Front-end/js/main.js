// My Header Template
class MyHeader extends HTMLElement{
    connectedCallback(){
        this.innerHTML = `
        <!-- Start Header -->
    <header>
        <div class = "home-page">
            <div class="header-area">
                <div class="logo">
                    <img src="../Front-End/images/book.png" width="7%" id="book" alt="">
                    <span>S</span>tudy<span>B</span>uddy
                </div>
        
                <ul class="links">
                    <li><a href="../Front-End/index.html">Home</a></li>
                    <li><a href="../Front-End/sign.html">Sign In/Sign Up</a></li>
                    <li><a href="../Front-End/index.html">About</a></li>
                </ul>
            </div>
        </div>
    </header>
        <!-- End Header -->`
    }
}

customElements.define('my-header', MyHeader)


// My MyFooter Template
class MyFooter extends HTMLElement{
    connectedCallback(){
        this.innerHTML = `
        <!-- Start footer -->
        <footer>
          <div class="footer">
              <h1 class="credit text-center mx-auto">Created by <span>Team 31 Group 4</span> | all rights reserved © 2021.</h1>
          </div>
        </footer>
        <!-- End footer -->`
    }
}

customElements.define('my-footer', MyFooter)
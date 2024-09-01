(function() {
  // get data using fetch/xhr request from models (controllers->models->controllers->views)
  const softDrinksData = [
    {
      id: 0,
      name: "San Mig Pilsen",
      imageSource: "images/a1.png",
      quantity: 10 // maximum possible quantity
    },
    {
      id: 1,
      name: "San Mig Pilsen 2",
      imageSource: "images/a1.png",
      quantity: 2 // maximum possible quantity
    },
    {
      id: 2,
      name: "San Mig Pilsen 3",
      imageSource: "images/sample.webp",
      quantity: 10 // maximum possible quantity
    },
  ]

  const cardsWrapper = document.querySelector("[data-card-wrapper]")
  if (!cardsWrapper) return

  softDrinksData.forEach(item => {
    const card = createCard(item.name, item.imageSource, item.quantity)
    cardsWrapper.append(card)
  })
  
  function createCard(name, imageSource, quantity) {
    const card = document.createElement('div')
    card.classList = "p-6 pb-14 flex flex-col gap-5 bg-[radial-gradient(circle,_#FFEA00,_#EC9D00)]"

    const title = document.createElement('p')
    title.classList = "uppercase mb-4 text-lg font-bold max-w-max rounded-full text-black py-2 px-4 bg-white shadow-[10px_10px_5px_5px_rgba(0,0,0,0.25)]"
    title.textContent = name

    const imageWrapper = document.createElement("div")
    imageWrapper.classList = "aspect-[18/9] h-72 flex justify-center mb-4"

    const image = document.createElement("img")
    image.classList = "h-full object-contain"
    image.src = imageSource
    imageWrapper.append(image)

    const quantityWrapper = document.createElement("div")
    quantityWrapper.classList = "flex items-center justify-center gap-2"

    const quantityDecrement = qtySelector("decrement")
    const quantityIncrement = qtySelector("increment")

    const quantityOutput = document.createElement("div")
    quantityOutput.classList = "product-input uppercase text-lg font-medium text-black pointer-none"
    quantityOutput.setAttribute("data-quantity-max", quantity)
    quantityOutput.setAttribute("data-quantity", 1)
    quantityOutput.setAttribute("data-prefix", "CASE")
    quantityOutput.setAttribute("data-product-name", name)
    quantityOutput.textContent = "1 CASE"

    quantityWrapper.appendChild(quantityDecrement)
    quantityWrapper.appendChild(quantityOutput)
    quantityWrapper.appendChild(quantityIncrement)

    card.appendChild(title)
    card.appendChild(imageWrapper)
    card.appendChild(quantityWrapper)
    return card
  }

  // returns a new element
  function qtySelector(type) {
    const qty = document.createElement("button")
    qty.classList = "w-10 h-10 p-1 cursor-pointer rounded-full bg-white"

    switch(type) {
      case "increment":
        qty.innerHTML = incrementIcon()
        qty.addEventListener("click", incrementHandler)
        break
      default:
        qty.innerHTML = decrementIcon()
        qty.addEventListener("click", decrementHandler)
        break
    }


    return qty
  }

  function decrementIcon() {
    return `
      <svg class="w-full h-full" viewBox="0 0 110 54" fill="none" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
        <rect width="110" height="54" fill="url(#pattern0_9_150)"/>
        <defs>
        <pattern id="pattern0_9_150" patternContentUnits="objectBoundingBox" width="1" height="1">
        <use xlink:href="#image0_9_150" transform="matrix(0.00195312 0 0 0.00397859 0 -0.518519)"/>
        </pattern>
        <image id="image0_9_150" width="512" height="512" xlink:href="data:image/png;base64,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"/>
        </defs>
      </svg>    
    `
  }

  function incrementIcon() {
    return `
      <svg class="w-full h-full" viewBox="0 0 104 103" fill="none" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
        <rect width="104" height="103" fill="url(#pattern0_9_156)"/>
        <defs>
        <pattern id="pattern0_9_156" patternContentUnits="objectBoundingBox" width="1" height="1">
        <use xlink:href="#image0_9_156" transform="matrix(0.00195312 0 0 0.00197209 0 -0.00485437)"/>
        </pattern>
        <image id="image0_9_156" width="512" height="512" xlink:href="data:image/png;base64,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"/>
        </defs>
      </svg> 
    `
  }
  
  function incrementHandler(e) {
    e.preventDefault()
    const input = e.currentTarget.previousElementSibling
    let prevQuantity    = parseInt(input.getAttribute("data-quantity"))
    const maxQuantity   = parseInt(input.getAttribute("data-quantity-max"))
    const productName   = input.getAttribute("data-product-name")

    const temp = prevQuantity + 1

    if (temp > maxQuantity) {
      alert(`${productName} has ${maxQuantity < 2 ? "only " : ""}${maxQuantity} ${maxQuantity > 1 ? "stocks" : "stock"} left.`)
      return
    }

    input.setAttribute("data-quantity", temp)
    input.textContent = `${temp} ${temp > 1 ? "CASES" : "CASE"}`
  }
  
  function decrementHandler(e) {
    e.preventDefault()
    const input = e.currentTarget.nextElementSibling
    let prevQuantity    = parseInt(input.getAttribute("data-quantity"))
    const min           = 0
    const productName   = input.getAttribute("data-product-name")

    const temp = prevQuantity - 1

    if (temp <= min) return

    input.setAttribute("data-quantity", temp)
    input.textContent = `${temp} ${temp > 1 ? "CASES" : "CASE"}`
  }
})()
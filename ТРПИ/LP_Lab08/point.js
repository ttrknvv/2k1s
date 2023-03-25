$(document).ready(function(){
    // табы на js
    document.querySelector('#surname').addEventListener('blur', function(){
        if (!/^[A-Za-z]+$/.test(this.value)){
            alert("Некорректная фамилия");
        }
    })
    document.querySelector('#name').addEventListener('blur', function(){
        if (!/^[A-Za-z]+$/.test(this.value)){
            alert("Некорректное имя");
        }
    })
    document.querySelector('#datebirth').addEventListener('blur', function(){
        if (!/^\d{2}([.])\d{2}\1\d{4}$/.test(this.value)){
            alert("Некорректная дата");
        }
    })

    $(".dws-form").on("click",".tab",function(){
        
        //удаление класса active
        $(".dws-form ").find(".active").removeClass("active");
        
        //добавляем active
        $(this).addClass("active");
        
        //выборка элемента по индексу 
        $(".tab-form").eq($(this).index()).addClass("active");
    })
});


$(function(){
    var data;
    $.ajax({
        method: "Get",
        url: "rockbands.json", 
        success: function(result){
            data = result;
            $("#bands").append("<option> Please Select </option>");
            for(prp in result){
                $("#bands").append("<option value ='" + prp + "'>" + prp + "</option>")
            }
            
        }
    });

    
    $('#bands').change(function () {
        var band = $(this).val();
        $("#artists").html("");
            $("#artists").append("<option> Please Select </option>");
            for(i in data[band])
            {
                $("#artists").append("<option value ='" + data[band][i].value + "'>" + data[band][i].name + "</option>")
            }
    });

    $("#artists").change(function(){
        window.location.href = $('#artists option:selected').val();
    })
})
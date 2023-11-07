$.ajax({
    url: "https://pokeapi.co/api/v2/pokemon/",
    //success: (result) => {
    //    console.log(result);
    //}
}).done((result) => {
    console.log(result)
    let temp = "";
    $.each(result.results, (key, val) => {
        temp += `<tr>
                    <td>${key + 1}</td>
                    <td>${val.name}</td>
                    <td><button type="button" onclick="detail('${val.url}')" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modalPoke">Detail</button></td>
                </tr >`;
    });
    $("#tbodyPoke").html(temp);


}).fail((error) => {
    console.log(error);
})

// Foto(sprites), Jurus(move), Tyep Pokemon(badge), Nama Pokemon
function detail(stringUrl) {
    $.ajax({
        url: stringUrl
    }).done((res) => {
        let ability = "";
        let type = "";
        console.log(res)
        // $("#img").html(res.sprites.other.dream_world.front_default);
        $("#img").attr("src", res.sprites.other.dream_world.front_default);
        $("#img").width(200);
        // $("#img2").attr("src", res.sprites.back_default);
        // $("#img2").width(200);
        $("#nama").html(res.name);
        $.each(res.abilities, (key, val) => {
            console.log("key", key, "valu", val.ability.name);

            if (ability.length == 0) {
                ability += `<label class="ms-3">${val.ability.name}</label>`
            } else {
                ability += `<label>, ${val.ability.name}</label>`
            }
        });
        $("#ability").html(ability);
        $.each(res.types, (key, val) => {
            console.log("key", key, "valu", val.type.name);
            type += `<button type="button" class="m-1 btn btn-sm position-relative ${"type-" + val.type.name}"
            style="color:white">
            ${kapitalFirst(val.type.name)} </button>`;
            console.log(type);
            // type += `<label class="ms-3">${val.type.name}&nbsp;</label> `
        });
        $("#type").html(type);
        $("#hpStat").html(res.stats[0].base_stat);
        // $("#hpStat").style.width = res.stats[0].base_stat + "%";
        // console.log(res.stats[0].stat.name);
        for (let index = 0; index < res.stats.length; index++) {
            let temp = res.stats[index].stat.name;
            console.log(temp);
            if (temp != "special-attack" && temp != "special-defense") {
                console.log(index, "valu", res.stats[index]);
                stat = res.stats[index].base_stat;
                $(`#${temp}Stat`).html(stat);
                var element = document.getElementById(`${temp}Stat`);
                element.style.width = `${stat}%`;
            }
        }
    })
}

function kapitalFirst(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}
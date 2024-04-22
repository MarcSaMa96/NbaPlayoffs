function addListeners(conferenciaEste, conferenciaOeste) {
    // Eventos Conferencia Este
    $("#este-2round-bracket0").change(function () {
        var equipoIdSeleccionado = $(this).val();
        var bracket = 0;
        var bracketGroup = $(this).data("bracketgroup");

        actualizarBracketSegundaRonda(equipoIdSeleccionado, "#este-3round-bracket0", bracket, conferenciaEste, bracketGroup);
    });

    $("#este-2round-bracket1").change(function () {
        var equipoIdSeleccionado = $(this).val();
        var bracket = 1;
        var bracketGroup = $(this).data("bracketgroup");

        actualizarBracketSegundaRonda(equipoIdSeleccionado, "#este-3round-bracket0", bracket, conferenciaEste, bracketGroup);
    });

    $("#este-2round-bracket2").change(function () {
        var equipoIdSeleccionado = $(this).val();
        var bracket = 2;
        var bracketGroup = $(this).data("bracketgroup");

        actualizarBracketSegundaRonda(equipoIdSeleccionado, "#este-3round-bracket1", bracket, conferenciaEste, bracketGroup);
    });

    $("#este-2round-bracket3").change(function () {
        var equipoIdSeleccionado = $(this).val();
        var bracket = 3;
        var bracketGroup = $(this).data("bracketgroup");

        actualizarBracketSegundaRonda(equipoIdSeleccionado, "#este-3round-bracket1", bracket, conferenciaEste, bracketGroup);
    });

    $("#este-3round-bracket0").change(function () {
        var equipoIdSeleccionado = $(this).val();
        var bracketGroup = $(this).data("bracketgroup");

        actualizarBracketSemifinalConf(bracketGroup, conferenciaEste, equipoIdSeleccionado, "#este-2round-bracket0", "#este-2round-bracket1", "#winner_east1", "#winner_east2");
    });

    $("#este-3round-bracket1").change(function () {
        var equipoIdSeleccionado = $(this).val();
        var bracketGroup = $(this).data("bracketgroup");

        actualizarBracketSemifinalConf(bracketGroup, conferenciaEste, equipoIdSeleccionado, "#este-2round-bracket2", "#este-2round-bracket3", "#winner_east2", "#winner_east1");
    });

    $("#winner_east1").change(function () {
        selectConferenceChampion($("#este-3round-bracket0").val(), conferenciaEste);
    });

    $("#winner_east2").change(function () {
        selectConferenceChampion($("#este-3round-bracket1").val(), conferenciaEste);
    });

    // Eventos Conferencia Oeste
    $("#oeste-2round-bracket0").change(function () {
        var equipoIdSeleccionado = $(this).val();
        var bracket = 0;
        var bracketGroup = $(this).data("bracketgroup");

        actualizarBracketSegundaRonda(equipoIdSeleccionado, "#oeste-3round-bracket0", bracket, conferenciaOeste, bracketGroup);
    });

    $("#oeste-2round-bracket1").change(function () {
        var equipoIdSeleccionado = $(this).val();
        var bracket = 1;
        var bracketGroup = $(this).data("bracketgroup");

        actualizarBracketSegundaRonda(equipoIdSeleccionado, "#oeste-3round-bracket0", bracket, conferenciaOeste, bracketGroup);
    });

    $("#oeste-2round-bracket2").change(function () {
        var equipoIdSeleccionado = $(this).val();
        var bracket = 2;
        var bracketGroup = $(this).data("bracketgroup");

        actualizarBracketSegundaRonda(equipoIdSeleccionado, "#oeste-3round-bracket1", bracket, conferenciaOeste, bracketGroup);
    });

    $("#oeste-2round-bracket3").change(function () {
        var equipoIdSeleccionado = $(this).val();
        var bracket = 3;
        var bracketGroup = $(this).data("bracketgroup");

        actualizarBracketSegundaRonda(equipoIdSeleccionado, "#oeste-3round-bracket1", bracket, conferenciaOeste, bracketGroup);
    });

    $("#oeste-3round-bracket0").change(function () {
        var equipoIdSeleccionado = $(this).val();
        var bracketGroup = $(this).data("bracketgroup");

        actualizarBracketSemifinalConf(bracketGroup, conferenciaOeste, equipoIdSeleccionado, "#oeste-2round-bracket0", "#oeste-2round-bracket1", "#winner_west1", "#winner_west2");
    });

    $("#oeste-3round-bracket1").change(function () {
        var equipoIdSeleccionado = $(this).val();
        var bracketGroup = $(this).data("bracketgroup");

        actualizarBracketSemifinalConf(bracketGroup, conferenciaOeste, equipoIdSeleccionado, "#oeste-2round-bracket2", "#oeste-2round-bracket3", "#winner_west2", "#winner_west1");
    });

    $("#winner_west1").change(function () {
        selectConferenceChampion($("#oeste-3round-bracket0").val(), conferenciaOeste);
    });

    $("#winner_west2").change(function () {
        selectConferenceChampion($("#oeste-3round-bracket1").val(), conferenciaOeste);
    });

    $("#final-nba").change(function () {
        selectNbaChampion((conferenciaEste.concat(conferenciaOeste)).filter(x => x.playoffRank > 3));
    });
}

function actualizarBracketSemifinalConf(bracketGroup, conferencia, equipoSeleccionado, ronda2braquet0, ronda2braquet1, idOwnRadio, idOtherRadio) {

    $.each(conferencia.filter(equipo => equipo.bracketGroup == bracketGroup && equipo.playoffRank > 2), function (index, equipo) {
        equipo.playoffRank = 2;
    });

    if (equipoSeleccionado != "") {
        var equipo = conferencia.filter(equipo => equipo.teamRecordId == equipoSeleccionado)[0];
        equipo.playoffRank = 3;

        $(ronda2braquet0).attr("disabled", true);
        $(ronda2braquet1).attr("disabled", true);
    }
    else {
        $(ronda2braquet0).attr("disabled", false);
        $(ronda2braquet1).attr("disabled", false);
    }

    // Si se ha seleccionado ya los dos finalistas, habilitamos los radio buttons para seleccionar ganador
    if (conferencia.filter(x => x.playoffRank == 3).length == 2) {
        $(idOwnRadio).attr("disabled", false);
        $(idOtherRadio).attr("disabled", false);
    }
    else {
        $(idOwnRadio).attr("disabled", true);
        $(idOtherRadio).attr("disabled", true);
        $(idOwnRadio).prop("checked", false);
        $(idOtherRadio).prop("checked", false);
    }

    // Si esta chequeado vamos a llamar a seleccionar campeón
    if ($(idOwnRadio).prop("checked")) {
        selectConferenceChampion(equipoSeleccionado, conferencia);
    }
}

function actualizarBracketSegundaRonda(equipoSeleccionado, idBracketActualizar, bracket, conferencia, bracketGroup) {

    $(idBracketActualizar).empty();
    $(idBracketActualizar).append('<option></option>');

    $.each(conferencia.filter(equipo => equipo.bracket == bracket), function (index, equipo) {
        equipo.playoffRank = 1;
    });

    if (equipoSeleccionado != "") {
        var equipo = conferencia.filter(equipo => equipo.teamRecordId == equipoSeleccionado)[0];
        equipo.playoffRank = 2;
    }

    var finalistasConferenciaBracket = conferencia.filter(e => e.bracketGroup == bracketGroup && e.playoffRank == 2);

    $.each(finalistasConferenciaBracket, function (index, team) {
        $(idBracketActualizar).append('<option value="' + team.teamRecordId + '">' + team.teamName + '</option>');
    });

    // Si están las dos opciones disponibles habilitamos el select de final de conferencia
    if (finalistasConferenciaBracket.length == 2) {
        $(idBracketActualizar).attr("disabled", false);
    }
    else {
        $(idBracketActualizar).attr("disabled", true);
    }
}

function selectConferenceChampion(teamRecordId, conferencia) {
    $.each(conferencia.filter(equipo => equipo.playoffRank > 3), function (index, equipo) {
        equipo.playoffRank = 3;
    });

    // Eliminamos la option del select de la final si es que existe una option para esta conferencia
    $("#final-nba option").each(function () {
        var valorOption = $(this).val();

        for (var i = 0; i < conferencia.length; i++) {
            if (valorOption == conferencia[i].teamRecordId) {
                $(this).remove();
                break;
            }
        }
    });

    if (teamRecordId != "") {
        var equipo = conferencia.filter(equipo => equipo.teamRecordId == teamRecordId)[0];
        equipo.playoffRank = 4;
        $("#final-nba").append('<option value="' + equipo.teamRecordId + '">' + equipo.teamName + '</option>');
    }

    if ($("#final-nba option").length == 3) {
        $("#final-nba").prop("disabled", false);
    }
    else {
        $("#final-nba").prop("disabled", true);
    }
}

function selectNbaChampion(finalists) {
    var idTeamChampion = $("#final-nba").val();

    $.each(finalists, function (index, finalist) {
        if (finalist.teamRecordId == idTeamChampion) {
            finalist.playoffRank = 5;
        }
        else {
            finalist.playoffRank = 4;
        }
    });
}
<template>
  <div class="HeaderStyle">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link" href="/Patient">Patient</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="/Wartezimmer">Wartezimmer</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="/Abrechnung">Abrechnung</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="/Rechnung">Rechnung</a>
        </li>
<!--        <li class="nav-item">
          <a class="nav-link" href="#">Statistik</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Kommunikation</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Formulare</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Verwaltung</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Abrechnung</a>
        </li>
//-->
      </ul>
      <ul class="navbar-nav  ml-auto">
        <li class="nav-item">
          <a class="nav-link" href="/Einstellungen">Einstellungen</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="/Zusatzmodule">Zusatzmodule</a>
        </li>
      </ul>
    </nav>
    <hr />
  </div>
</template>

<script>
export default {
}
</script>

<style scoped>
.HeaderStyle{
  margin-top: 5px;
  width: 100%;
}
hr{
  margin-top:0px;
}
</style>

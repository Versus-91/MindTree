<template>
    <div>
        <LazyTableComponent @selected="show" :rows="[{ 'sd': 2 }]" :headers="['sd']"></LazyTableComponent>
        Switch: {{ flag }}
    </div>
</template>

<script setup lang="ts">
const flag = ref(false);

function show(e: unknown) {
    alert(e);
    flag.value = !flag.value;
}
</script>

<style scoped></style>
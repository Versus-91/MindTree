<template>
    <table class="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
        <thead>
            <tr>
                <th v-for="header in headers">{{ header }}</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="row in rows">
                <td v-for="header in headers" @click="notifySelect(row[header])">{{ row[header] }}</td>
            </tr>
        </tbody>
    </table>
</template>

<script setup lang="ts">
withDefaults(defineProps<{ rows: Record<string, unknown>[], headers: string[] }>(), {

    rows: () => [{ 'one': 1 }, { 'two': 2 }]
});
const emit = defineEmits(['selected'])
function notifySelect(value: unknown): void {
    emit('selected', value)
}
</script>

<style scoped></style>
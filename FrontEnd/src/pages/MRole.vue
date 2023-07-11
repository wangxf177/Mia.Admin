<template>
  <div class="q-pa-md">
    <q-card flat>
      <q-card-section class="row q-gutter-x-md items-center">
        <q-btn color="primary" :label="$t('Search')" />
        <q-btn color="primary" :label="$t('Reset')" />
      </q-card-section>
      <q-card-section class="row q-gutter-x-md items-center">
        <q-table
          title="角色管理"
          :rows="rows"
          :columns="columns"
          row-key="name"
          :pagination="{ rowsPerPage: 8 }"
          table-header-class="bg-blue"
        >
          <template v-slot:top>
            <q-btn-group spread outline glossy push unelevated class="q-pa-sm">
              <q-btn color="secondary" icon="add" label="新增" push />
              <q-btn color="secondary" icon="edit" label="修改" push />
              <q-btn color="secondary" icon="delete" label="删除" push />
              <q-btn color="secondary" icon="upload" label="导入" push />
              <q-btn color="secondary" icon="download" label="导入" push />
            </q-btn-group>
          </template>
        </q-table>
      </q-card-section>
    </q-card>
  </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue';
const columns = [
  { name: 'name', label: '角色编号', align: 'center', field: 'name' },
  { name: 'calories', align: 'center', label: '角色名称', field: 'calories' },
  { name: 'fat', label: '权限字符', field: 'fat', align: 'center' },
  { name: 'carbs', label: '显示顺序', field: 'carbs', align: 'center' },
  { name: 'protein', label: '状态', field: 'protein', align: 'center' },
  { name: 'sodium', label: '创建时间', field: 'sodium', align: 'center' },
  { name: 'calcium', label: '操作', field: 'calcium', align: 'center' },
];

const rows = ref([
  {
    name: 'Frozen Yogurt',
    calories: 159,
    fat: 6.0,
    carbs: 24,
    protein: 4.0,
    sodium: 87,
    calcium: '14%',
    iron: '1%',
  },
  {
    name: 'Ice cream sandwich',
    calories: 237,
    fat: 9.0,
    carbs: 37,
    protein: 4.3,
    sodium: 129,
    calcium: '8%',
    iron: '1%',
  },
  {
    name: 'Eclair',
    calories: 262,
    fat: 16.0,
    carbs: 23,
    protein: 6.0,
    sodium: 337,
    calcium: '6%',
    iron: '7%',
  },
  {
    name: 'Cupcake',
    calories: 305,
    fat: 3.7,
    carbs: 67,
    protein: 4.3,
    sodium: 413,
    calcium: '3%',
    iron: '8%',
  },
  {
    name: 'Gingerbread',
    calories: 356,
    fat: 16.0,
    carbs: 49,
    protein: 3.9,
    sodium: 327,
    calcium: '7%',
    iron: '16%',
  },
  {
    name: 'Jelly bean',
    calories: 375,
    fat: 0.0,
    carbs: 94,
    protein: 0.0,
    sodium: 50,
    calcium: '0%',
    iron: '0%',
  },
  {
    name: 'Lollipop',
    calories: 392,
    fat: 0.2,
    carbs: 98,
    protein: 0,
    sodium: 38,
    calcium: '0%',
    iron: '2%',
  },
  {
    name: 'Honeycomb',
    calories: 408,
    fat: 3.2,
    carbs: 87,
    protein: 6.5,
    sodium: 562,
    calcium: '0%',
    iron: '45%',
  },
  {
    name: 'Donut',
    calories: 452,
    fat: 25.0,
    carbs: 51,
    protein: 4.9,
    sodium: 326,
    calcium: '2%',
    iron: '22%',
  },
  {
    name: 'KitKat',
    calories: 518,
    fat: 26.0,
    carbs: 65,
    protein: 7,
    sodium: 54,
    calcium: '12%',
    iron: '6%',
  },
]);
</script>

import matplotlib.pyplot as plt
import pandas as pd
import sys

"""
Read a csv file and return a tuple of three dataframes
"""
def read_data(filename: str) -> tuple[pd.DataFrame, pd.DataFrame, pd.DataFrame]:
  df = pd.read_csv(filename)
  merge_sort = df.iloc[:, 0]
  quick_sort = df.iloc[:, 1]
  sizes = df.iloc[:, 2]
  return merge_sort, quick_sort, sizes

"""
Plot the data
"""
def plot(
    merge_sort: pd.DataFrame, 
    quick_sort: pd.DataFrame, 
    sizes: pd.DataFrame) -> None:
  plt.plot(sizes, merge_sort, label='Merge Sort')
  plt.plot(sizes, quick_sort, label='Quick Sort')
  plt.xlabel('Size')
  plt.ylabel('Time')
  # plt.xscale('log', base=2)
  # plt.yscale('log', base=2)
  plt.title('Merge Sort vs Quick Sort')
  plt.legend()

if __name__ == '__main__':
  merge_sort, quick_sort, sizes = read_data(sys.argv[1])
  plot(merge_sort, quick_sort, sizes)
  plt.savefig(sys.argv[1].split('.')[0] + '.png')
